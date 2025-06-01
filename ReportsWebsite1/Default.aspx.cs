//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page 
{
    string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Student();
        }
    }
     public void Load_Student()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM students", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Grideviewstudent.DataSource = dt;
            Grideviewstudent.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Value;
        int age = Convert.ToInt32(txtAge.Value);
        string email = txtEmail.Value;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd;
            if (!string.IsNullOrEmpty(hdnId.Value))
            {
                cmd = new SqlCommand("UPDATE students SET FullName=@FullName, Age=@Age, Email=@Email WHERE studentId=@studentId", conn);
                cmd.Parameters.AddWithValue("@studentId", Convert.ToInt32(hdnId.Value));
                
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO students (FullName, Age, Email) VALUES (@FullName, @Age, @Email)", conn);
                
            }
            cmd.Parameters.AddWithValue("@FullName", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Email", email);

            cmd.ExecuteNonQuery();
            lblMessage.Text = "Record saved successfully!";
        }
        clearForm();
        Load_Student();
    }
    void clearForm()
    {
        txtName.Value = string.Empty;
        txtAge.Value = string.Empty;
        txtEmail.Value = string.Empty;
        hdnId.Value = string.Empty;
        //Load_Student();
    }
    protected void Grideviewstudent_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Grideviewstudent.EditIndex = -1;
        int studentId = Convert.ToInt32(Grideviewstudent.DataKeys[e.NewEditIndex].Value);
        using (SqlConnection conn=new SqlConnection(connectionString))
        {
            SqlCommand cmd=new SqlCommand("SELECT * FROM students WHERE studentId=@studentId", conn);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Value = reader["FullName"].ToString();
                txtAge.Value = reader["Age"].ToString();
                txtEmail.Value = reader["Email"].ToString();
                hdnId.Value = reader["studentId"].ToString();
            }
        }
    }

    protected void Grideviewstudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
