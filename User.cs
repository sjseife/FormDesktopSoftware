using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public class User
{
    public int user_id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string salt { get; set; }
    public int pw_reset_flag { get; set; }
    public string f_name { get; set; }
    public string l_name { get; set; }
    public string address_street { get; set; }
    public string address_number { get; set; }
    public string address_city { get; set; }
    public string address_state { get; set; }
    public string address_zip { get; set; }
    public string primary_phone { get; set; }
    public string user_title { get; set; }
    public int user_level { get; set; }
    
    private MySqlConnection Connection;
    private MySqlCommand cmd;


    public User(int userID)
	{
        string serverName = "server=einstein.etsu.edu";
        string databaseName = "database=schaum";
        string username = "uid=schaum";
        string password = "pwd=12345";

        Connection = new MySqlConnection(string.Format("{0};{1};{2};{3}", serverName, databaseName, username, password));
        cmd.CommandText = "SELECT * FROM user_accounts WHERE user_id =" + userID;

        try
        {
            Connection.Open();
            
        }
        catch
        {
            MessageBox.Show("Connection Error!");
            Environment.Exit(1);
        }

        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            this.user_id = (int)reader["user_id"];//set user_id from database query results
            this.username = (string)reader["username"];//set username from database query results
            this.email = (string)reader["email"];//set email from database query results
            this.password = (string)reader["password"];// set password from database query results
            this.pw_reset_flag = (int)reader["pw_reset_flag"];//set pw_reset_flag from database query results
            this.f_name = (string)reader["f_name"];//set f_name from database query results
            this.l_name = (string)reader["l_name"];//set l_name from database query results
            this.address_street = (string)reader["address_street"]; //set address_street from database query results
            this.address_number = (string)reader["address_number"]; //set address_number from database query results 
            this.address_city = (string)reader["address_city"]; //set address_city from database query results
            this.address_state = (string)reader["address_state"];//set address_state from database query results
            this.address_zip = (string)reader["address_zip"];//set address_zip from database query results
            this.primary_phone = (string)reader["primary_phone"];//set primary_phone from database query results
            this.user_title = (string)reader["user_title"];//set user_title from database query results
            this.user_level = (int)reader["user_level"];//set user_level from database query results
        }
        Connection.Close();



    }//end constructor with userID as param


    public User(string uName)
    {
        string serverName = "server=einstein.etsu.edu";
        string databaseName = "database=schaum";
        string username = "uid=schaum";
        string password = "pwd=12345";

        Connection = new MySqlConnection(string.Format("{0};{1};{2};{3}", serverName, databaseName, username, password));
        cmd.CommandText = "SELECT * FROM user_accounts WHERE username =" + uName;

        try
        {
            Connection.Open();
           
        }
        catch
        {
            MessageBox.Show("Connection Error!");
            Environment.Exit(1);
        }

        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {

            this.user_id = (int)reader["user_id"];//set user_id from database query results
            this.username = (string)reader["username"];//set username from database query results
            this.email = (string)reader["email"];//set email from database query results
            this.password = (string)reader["password"];// set password from database query results
            this.pw_reset_flag = (int)reader["pw_reset_flag"];//set pw_reset_flag from database query results
            this.f_name = (string)reader["f_name"];//set f_name from database query results
            this.l_name = (string)reader["l_name"];//set l_name from database query results
            this.address_street = (string)reader["address_street"]; //set address_street from database query results
            this.address_number = (string)reader["address_number"]; //set address_number from database query results 
            this.address_city = (string)reader["address_city"]; //set address_city from database query results
            this.address_state = (string)reader["address_state"];//set address_state from database query results
            this.address_zip = (string)reader["address_zip"];//set address_zip from database query results
            this.primary_phone = (string)reader["primary_phone"];//set primary_phone from database query results
            this.user_title = (string)reader["user_title"];//set user_title from database query results
            this.user_level = (int)reader["user_level"];//set user_level from database query results
        }
        Connection.Close();



    }//end constructor with uName as param
}