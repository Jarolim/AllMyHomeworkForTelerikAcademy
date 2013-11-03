-- add column for field _property1
ALTER TABLE [Categories] ADD [Property1] varchar(255) NULL

go

-- DbFirst.DomainClass1
CREATE TABLE [DomainClass1] (
    [Id] int NOT NULL,                      -- _id
    [Property1] varchar(255) NULL,          -- _property1
    CONSTRAINT [pk_DomainClass1] PRIMARY KEY ([Id])
)

go

