USE [ZhpGame]
GO

/****** Object:  StoredProcedure [dbo].[P_PagerQuery]    Script Date: 2017/7/27 17:37:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- Batch submitted through debugger: SQLQuery19.sql|7|0|C:\Users\Randy\AppData\Local\Temp\~vs43F7.sql

CREATE PROCEDURE [dbo].[P_PagerQuery] (
    @recordTotal INT OUTPUT,          --输出记录总数
	@pageTotal INT OUTPUT,            --输出分页总页数
    @tblName VARCHAR(800),			  --表名
    @fldName VARCHAR(800) = '*',      --查询字段
	@pageSize INT = 20,               --每页记录数
	@pageIndex INT =1,                --当前页
    @keyName VARCHAR(200) = 'Id',     --索引字段  
    @orderString VARCHAR(200),        --排序条件
    @whereString VARCHAR(800) = '1=1' --WHERE条件
)
AS
BEGIN
     DECLARE @beginRow INT					--开始行
     DECLARE @endRow INT					--结束行
     DECLARE @tempLimit VARCHAR(200)		--between 开始行 与结束行之间
     DECLARE @tempCount NVARCHAR(1000)		--输出总记录数sql
      DECLARE @tempMain NVARCHAR(1000)	--返回分页结果集
	 DECLARE @tempPageCount NVARCHAR(1000)	--输出总页数sql
     --declare @timediff datetime 
     
     set nocount on
     --select @timediff=getdate() --记录时间

     SET @beginRow = (@pageIndex - 1) * @pageSize    + 1 
     SET @endRow = @pageIndex * @pageSize		
     SET @tempLimit = 'rows BETWEEN ' + CAST(@beginRow AS VARCHAR) +' AND '+CAST(@endRow AS VARCHAR)
     
     --输出参数为总记录数
     SET @tempCount = 'SELECT @recordTotal = COUNT(*) FROM (SELECT '+@keyName+' FROM '+@tblName+' WHERE '+@whereString+') AS my_temp'
     EXECUTE sp_executesql @tempCount,N'@recordTotal INT OUTPUT',@recordTotal OUTPUT

	 --输出参数为总页数
	  SET @tempPageCount = 'select @pageTotal=(select Ceiling(cast(cast('+cast(@recordTotal as varchar(4))+' as float)/'+cast(@pageSize as varchar(4))+' as decimal(10,2))))'
     EXECUTE sp_executesql @tempPageCount,N'@pageTotal INT OUTPUT',@pageTotal OUTPUT
       
       
     --主查询返回结果集
     SET @tempMain = 'select * from (SELECT ROW_NUMBER() OVER (order by '+@orderString+') AS rows ,'+@fldName+' FROM '+@tblName+' WHERE '+@whereString+')as temptb Where '+  @tempLimit
     
     EXECUTE sp_executesql @tempMain

     --PRINT @tempMain
    -- EXECUTE (@tempMain)
     --select datediff(ms,@timediff,getdate()) as 耗时 
     
     set nocount off
END




GO


