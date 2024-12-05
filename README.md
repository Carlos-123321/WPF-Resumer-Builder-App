![image](https://github.com/user-attachments/assets/63bf7e0d-21bb-4fda-bd84-1788e38a3c98)
![image](https://github.com/user-attachments/assets/3b36cd98-11a5-4bbb-9b73-7e6ded8373ce)
![image](https://github.com/user-attachments/assets/c6cfdb43-401c-4630-97b8-723096474101)
![image](https://github.com/user-attachments/assets/3b72e190-528a-47f3-a109-c70b37351e0d)
![image](https://github.com/user-attachments/assets/6971332b-e175-41cb-817c-6a939ebdf0f0)
![image](https://github.com/user-attachments/assets/29c2ca8e-7cb4-42ab-b98d-1be82889c4c5)
![image](https://github.com/user-attachments/assets/ad0f9f26-bb78-4b31-a424-80c93f2441cf)


IMPORTANT:

The project is going to give you an error because in the App.Config of WPFResumeBuilder I hard coded the path for the database. 

To fix this all you have to do is put your respective directories which lead to the
MySQLiteDB.db:

<connectionStrings>
	<add name="MyDB" connectionString="Data Source=C:\Users\carlo\Desktop\Please Work\WPFResumerBuilder\FunWithDBSQLite\FunWithDBSQLite\bin\Debug\MySQLiteDB.db"/>
</connectionStrings>



<connectionStrings>
	<add name="MyDB" connectionString="Data Source=C:Enter your corresponding
directories\WPFResumerBuilder\FunWithDBSQLite\FunWithDBSQLite\bin\Debug\MySQLiteDB.db"/>
</connectionStrings>
