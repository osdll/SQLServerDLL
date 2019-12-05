轻量级SQLSERVER操作库

Lightweight sqlserver operation Library

SQL Server功能类 使用说明 当前版本V3.5支持2000,2005,2008 更新：添加了高兴能事物处理机制 添加了数据库性能算法 倒入类库using SQL Server功能类; 一共有5个属性 SqlServerInterface con = SqlServer.创建连接("Microsoft SQL Server 2008", "aking", "sa","sa","."); 1987817是数据库密码 Access是数据库版本 注意格式例如；Access 2007请注意格式

SQL server function class instructions the current version v3.5 supports 2000, 2005, 2008 update: adding the happy thing processing mechanism, adding the database performance algorithm, pouring into the class library using SQL server function class; there are 5 properties in total sqlserverinterface con = sqlserver. Create a connection ("Microsoft SQL Server 2008", "aking", "Sa", "Sa", "Sa", "."); 1987817 is the database password access is the data Library version pay attention to format for example; access 2007 pay attention to format

第一个：著名的 登陆验证属性 例子 string u = ""select count(*) from table where(用户名=" + this.textBox1.Text + ") AND (密码=" + textBox2.Text + ")"; int i = ac.登陆验证(u);

The first one is the famous login authentication attribute example string u = "" select count (*) from table where (user name = "+ this. Textbox1. Text +") and (password = "+ textbox2. Text +") "; int i = AC. login authentication (U);

接受返回值大于0登陆成功小于0登陆失败

Accept return value greater than 0 login success less than 0 login failure

第二个：返回受影响行数 例子 string u = "DELETE from 留言表 where(姓名='"+this.textBox1.Text+"')"; int i = ac.返回受影响行数(u); 适合使用在增删改功能上。

Second: return the example of the number of affected rows string u = "delete from message table where (name = '" + this. Textbox1. Text + "'); int i = AC. return the number of affected rows (U); suitable for use in the function of adding, deleting and modifying.

第三个：数据集 例子 DataSet set; string u = "select * from 留言表"; set = ac.数据集(u); this.dataGridView1.DataSource = set.Tables[0]; 用于填充dataGridView控件

Third: dataset example dataset set; string u = "select * from message table"; set = AC. dataset (U); this. Datagridview1. Datasource = set. Tables [0]; used to populate DataGridView control

第四个：数据行 例子 OleDbDataReader re = ac.数据行("select * from 留言表"); while (re.Read()) { this.textBox1.Text = re[1].ToString(); } 适合用于将数据显示在控件上

Fourth: data row example oledbdatareader re = AC. data row ("select * from message table"); while (re. Read()) {this. Textbox1. Text = re [1]. Tostring();} is suitable for displaying data on the control

第五了：显示dataGridView数据 例子 string u = "select * from 留言表"; ac.显示dataGridView数据(this.dataGridView1, u);

Fifth, display DataGridView data example string u = "select * from message table"; AC. display DataGridView data (this. Datagridview1, U);

第六个：返回一个表 例子 string u = "select * from 留言表"; ac.返回数据表(u)；

Sixth: return a table example string u = "select * from message table"; AC. return data table (U);

还有好多功能大家去自己探究吧

There are many other functions. Let's explore them by ourselves
