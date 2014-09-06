CREATE DATABASE SqlPerformanceDB;
GO

USE SqlPerformanceDB;
GO

CREATE TABLE Logs(
  LogText nvarchar(300),
  LogDate datetime
);
GO

DECLARE @Counter int = 0
WHILE @Counter < 1000000
BEGIN
	DECLARE @RandomText nvarchar(350);
	DECLARE @length int = 50;
	DECLARE @lorem nvarchar(max) = ' lorem. Ut purus tellus, aliquet a dapibus quis, semper quis neque. Pellentesque tincidunt turpis eget orci scelerisque semper. Vivamus eget tellus eget libero ultricies porttitor eu eget lectus. Quisque ut elit ac magna faucibus mollis sed dapibus diam. In ut nibh eget erat fermentum blandit sed sed massa. Curabitur et magna a ipsum condimentum suscipit nec vestibulum mauris. Integer ut elit at quam posuere eleifend. Proin mollis placerat nunc vitae tincidunt. Pellentesque vitae enim sed arcu aliquet laoreet id nec urna. Nullam nulla massa, bibendum at commodo at, lobortis quis tellus. Mauris enim libero, hendrerit vitae vestibulum at, pharetra sed diam. Duis mauris nibh, tincidunt ut ornare eget, suscipit at nulla. Mauris quis diam vel eros commodo aliquam.
	Donec et faucibus nisl. Curabitur convallis turpis sed dolor molestie eget placerat nunc facilisis. Donec mauris diam, pulvinar non pellentesque ac, cursus a eros. Nullam nulla nunc, feugiat eget congue nec, dignissim ut magna. Aliquam id nulla tellus. Morbi imperdiet fringilla lacus a facilisis. Sed faucibus urna id turpis sollicitudin consectetur. In eget iaculis libero. Sed quis tellus nisi, nec posuere enim. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam suscipit orci in enim lobortis viverra. Integer vulputate scelerisque mauris, in porta urna imperdiet sed. Vivamus libero tellus, dictum sit amet condimentum non, hendrerit in diam. Nam ultrices ultrices leo, in adipiscing ante posuere sit amet. Integer gravida nunc et est mollis in suscipit dolor scelerisque. Fusce ultrices facilisis tortor ac rhoncus.
	Nunc sed orci justo, et egestas augue. Nulla id elit scelerisque justo aliquet ultricies. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Donec pretium sagittis mi, a blandit felis auctor sed. Morbi aliquam elit ac dui iaculis imperdiet. Integer a lectus quam, ut pellentesque elit. Suspendisse eget orci sed lectus commodo venenatis. Fusce interdum risus ac turpis tincidunt rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In malesuada nulla ut ante luctus facilisis. Vestibulum ac odio ante. Ut odio erat, placerat at condimentum et, adipiscing eu sapien. Ut nibh magna, eleifend eget rutrum vitae, mattis id sapien. Pellentesque quis ligula at turpis dignissim rutrum. Aenean nibh massa, varius in mattis quis, molestie eget massa.
	Curabitur quam nisl, eleifend a ';
	SET @RandomText = SUBSTRING(@lorem, CAST(ROUND((LEN(@lorem) - @length) * RAND(), 0) AS INT), @length)

	DECLARE @Date datetime = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
	INSERT INTO [SqlPerformanceDB].[dbo].[Logs](LogText, LogDate)
	VALUES (@RandomText, @Date)
	SET @Counter = @Counter + 1
END;
GO