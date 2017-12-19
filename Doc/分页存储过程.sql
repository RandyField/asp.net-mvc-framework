USE [ZhpGame]
GO

/****** Object:  StoredProcedure [dbo].[P_PagerQuery]    Script Date: 2017/7/27 17:37:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- Batch submitted through debugger: SQLQuery19.sql|7|0|C:\Users\Randy\AppData\Local\Temp\~vs43F7.sql

CREATE PROCEDURE [dbo].[P_PagerQuery] (
    @recordTotal INT OUTPUT,          --�����¼����
	@pageTotal INT OUTPUT,            --�����ҳ��ҳ��
    @tblName VARCHAR(800),			  --����
    @fldName VARCHAR(800) = '*',      --��ѯ�ֶ�
	@pageSize INT = 20,               --ÿҳ��¼��
	@pageIndex INT =1,                --��ǰҳ
    @keyName VARCHAR(200) = 'Id',     --�����ֶ�  
    @orderString VARCHAR(200),        --��������
    @whereString VARCHAR(800) = '1=1' --WHERE����
)
AS
BEGIN
     DECLARE @beginRow INT					--��ʼ��
     DECLARE @endRow INT					--������
     DECLARE @tempLimit VARCHAR(200)		--between ��ʼ�� �������֮��
     DECLARE @tempCount NVARCHAR(1000)		--����ܼ�¼��sql
      DECLARE @tempMain NVARCHAR(1000)	--���ط�ҳ�����
	 DECLARE @tempPageCount NVARCHAR(1000)	--�����ҳ��sql
     --declare @timediff datetime 
     
     set nocount on
     --select @timediff=getdate() --��¼ʱ��

     SET @beginRow = (@pageIndex - 1) * @pageSize    + 1 
     SET @endRow = @pageIndex * @pageSize		
     SET @tempLimit = 'rows BETWEEN ' + CAST(@beginRow AS VARCHAR) +' AND '+CAST(@endRow AS VARCHAR)
     
     --�������Ϊ�ܼ�¼��
     SET @tempCount = 'SELECT @recordTotal = COUNT(*) FROM (SELECT '+@keyName+' FROM '+@tblName+' WHERE '+@whereString+') AS my_temp'
     EXECUTE sp_executesql @tempCount,N'@recordTotal INT OUTPUT',@recordTotal OUTPUT

	 --�������Ϊ��ҳ��
	  SET @tempPageCount = 'select @pageTotal=(select Ceiling(cast(cast('+cast(@recordTotal as varchar(4))+' as float)/'+cast(@pageSize as varchar(4))+' as decimal(10,2))))'
     EXECUTE sp_executesql @tempPageCount,N'@pageTotal INT OUTPUT',@pageTotal OUTPUT
       
       
     --����ѯ���ؽ����
     SET @tempMain = 'select * from (SELECT ROW_NUMBER() OVER (order by '+@orderString+') AS rows ,'+@fldName+' FROM '+@tblName+' WHERE '+@whereString+')as temptb Where '+  @tempLimit
     
     EXECUTE sp_executesql @tempMain

     --PRINT @tempMain
    -- EXECUTE (@tempMain)
     --select datediff(ms,@timediff,getdate()) as ��ʱ 
     
     set nocount off
END




GO


