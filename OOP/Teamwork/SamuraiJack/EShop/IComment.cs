using System;

namespace EShop
{
    interface IComment
    {
        string Comment { get; set; }
        void PrintComment();
    }
}