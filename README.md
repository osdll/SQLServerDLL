# SQLServerDLL
轻量级SQLSERVER操作库

SQL Server功能类  使用说明  当前版本V3.5支持2000,2005,2008
更新：添加了高兴能事物处理机制
      添加了数据库性能算法
倒入类库using SQL Server功能类;
一共有5个属性
SqlServerInterface con = SqlServer.创建连接("Microsoft SQL Server 2008", "aking", "sa","sa",".");
1987817是数据库密码
Access是数据库版本
注意格式例如；Access 2007请注意格式



第一个：著名的   登陆验证属性  例子
string u = ""select count(*) from table where(用户名=" + this.textBox1.Text + ") AND (密码=" + textBox2.Text + ")";
int i = ac.登陆验证(u);  
接受返回值大于0登陆成功小于0登陆失败


第二个：返回受影响行数     例子
string u = "DELETE from 留言表 where(姓名='"+this.textBox1.Text+"')";
int i = ac.返回受影响行数(u);
适合使用在增删改功能上。


第三个：数据集   例子
DataSet set;
 string u = "select * from 留言表";
 set = ac.数据集(u);
 this.dataGridView1.DataSource = set.Tables[0];
 用于填充dataGridView控件



第四个：数据行  例子
OleDbDataReader re = ac.数据行("select * from 留言表");
while (re.Read())
{
    this.textBox1.Text = re[1].ToString();
}
适合用于将数据显示在控件上


第五了：显示dataGridView数据   例子
string u = "select * from 留言表";
ac.显示dataGridView数据(this.dataGridView1, u);

第六个：返回一个表  例子
string u = "select * from 留言表";
ac.返回数据表(u)；


还有好多功能大家去自己探究吧
