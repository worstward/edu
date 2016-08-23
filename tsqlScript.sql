drop table CourseDescription;
drop table Courses;

CREATE TABLE [dbo].[Courses] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (100)   NOT NULL,
    [Price] DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[CourseDescription] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [ShortDescription] VARCHAR (MAX) NULL,
    [LongDescription]  VARCHAR (MAX) NULL,
    [CourseLength]     INT            NULL,
    CONSTRAINT [PK_dbo.CourseDescription] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.CourseDescription_dbo.Courses_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Courses] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [IX_Id]
    ON [dbo].[CourseDescription]([Id] ASC);

	
insert into Courses (Name, Price) values (N'CourseName1', 1000);		
insert into CourseDescription (ShortDescription, LongDescription, CourseLength) values (N'Короткое описание курса 1', N'Длинное описание курса 1', 1000);

DECLARE @i int;
SET @i = 0;

WHILE (@i < 70)  
BEGIN  
	insert into Courses (Name, Price) values ('CourseName', 1000);
	insert into CourseDescription (ShortDescription, LongDescription, CourseLength) values (N'Короткое описание курса', 'Длинное описание курса', 1000);
	SET @i = @i + 1;
END