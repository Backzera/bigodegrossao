@echo off
set MYSQL_USER=root
set MYSQL_PASSWORD=SQLPASSWORD
set MYSQL_DATABASE=clients
set SQL_FILE=C:\x\clonetable.sql

:: Disable foreign key checks before import
echo Disabling foreign key checks...
mysql -u %MYSQL_USER% -p%MYSQL_PASSWORD% -e "SET FOREIGN_KEY_CHECKS=0;" %MYSQL_DATABASE%

:: Import the SQL file
echo Importing database...
mysql -u %MYSQL_USER% -p%MYSQL_PASSWORD% %MYSQL_DATABASE% < %SQL_FILE%

:: Re-enable foreign key checks after import
echo Re-enabling foreign key checks...
mysql -u %MYSQL_USER% -p%MYSQL_PASSWORD% -e "SET FOREIGN_KEY_CHECKS=1;" %MYSQL_DATABASE%

echo Database import complete!

:: Pause to allow user to read output
pause
