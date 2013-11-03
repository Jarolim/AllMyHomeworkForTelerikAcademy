//------------------------------------------------------------------------------
// <copyright file="Concat.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
    Format.UserDefined, /// Binary Serialization because of StringBuilder
    IsInvariantToOrder = false, /// order changes the result
    IsInvariantToNulls = true,  /// nulls don't change the result
    IsInvariantToDuplicates = false, /// duplicates change the result
    MaxByteSize = -1
    )]

public struct concat : IBinarySerialize
{
    private StringBuilder accumulator;
    private string delimiter;

    /// <summary>
    /// IsNull property
    /// </summary>
    public Boolean IsNull { get; private set; }

    public void Init()
    {
        accumulator = new StringBuilder();
        delimiter = string.Empty;
        this.IsNull = true;
    }

    public void Accumulate(SqlString Value, SqlString Delimiter)
    {
        if (!Delimiter.IsNull & Delimiter.Value.Length > 0)
        {
            delimiter = Delimiter.Value; /// save for Merge
                                          /// 
            if (accumulator.Length > 0)
            {
                accumulator.Append(Delimiter.Value);
            }
        }

        accumulator.Append(Value.Value);

        if (Value.IsNull == false)
        {
            this.IsNull = false;
        }
    }

    /// <summary>
    /// Merge onto the end 
    /// </summary>
    /// <param name="Group"></param>
    public void Merge(concat Group)
    {
        /// add the delimiter between strings
        if (accumulator.Length > 0 & Group.accumulator.Length > 0)
        {
            accumulator.Append(delimiter);
        }

        ///accumulator += Group.accumulator;
        accumulator.Append(Group.accumulator.ToString());
    }

    public SqlString Terminate()
    {
        // Put your code here
        return new SqlString(accumulator.ToString());
    }

    /// <summary>
    /// deserialize from the reader to recreate the struct
    /// </summary>
    /// <param name="reader">BinaryReader</param>
    void IBinarySerialize.Read(System.IO.BinaryReader reader)
    {
        delimiter = reader.ReadString();
        accumulator = new StringBuilder(reader.ReadString());

        if (accumulator.Length != 0)
        {
            this.IsNull = false;
        }
    }

    /// <summary>
    /// searialize the struct.
    /// </summary>
    /// <param name="writer">BinaryWriter</param>
    void IBinarySerialize.Write(System.IO.BinaryWriter writer)
    {
        writer.Write(delimiter);
        writer.Write(accumulator.ToString());
    }
}