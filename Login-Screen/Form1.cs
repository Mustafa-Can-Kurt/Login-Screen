using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Xml.Linq;

namespace Login_Screen
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        //In general, all codes perform user registration, update, deletion and login operations.
        //They form the skeleton of a desktop application.
        //All defined variables were kept as close to spoken language as possible, or the closest words were used based on association.
        private void Form1_Load(object sender, EventArgs e)
        {
            //Information to be displayed in textboxes where forms are opened
            TextLogUsername.Text = "Enter Your Username";
            TextLogPassword.Text = "Enter Your Password";
            TextName1.Text = "Name";
            TextSurname1.Text = "Surname";
            TextPassword4.Text = "Password";
            TextUsername4.Text = "Username";
            textAddress1.Text = "Address";
            TextUsername2.Text = "Username";
            TextPassword2.Text = "Password";
            TextMail2.Text = "Enter your Enail address";
            TextAddress3.Text = "Address";
            TextSurname1.Text = "Surname";
            Textname3.Text = "Name";
            TextMail1.Text = "Email";
            TextRePassword.Text = "Enter Your New Password";
            TextPassword3.Text = "Verify Your Password";
            TextCode.Text = "Enter the verification code";
            TextUsername3.Text = "Username";

        }


        private void Button2_Click(object sender, EventArgs e)
        {
           // It is specified which page in the tabcontrol tool will be redirected to when the button is clicked.
            Interface.SelectedIndex = 1;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Interface.SelectedIndex = 2;
        }
        private bool AuthenticateUser(string username, string password, string connectionString)
        {
            //When the user logs in, it is verified in the database.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM AccountInfo WHERE UserName = @UserName AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Password", password);
                    conn.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //When the login button is clicked, operations are performed depending on whether the verification is true or false.
            string connectionString = "Data Source=MUSTAFA-CAN;Initial Catalog=Login-Screen;Integrated Security=True;";
            var username = TextLogUsername.Text;
            var password = TextLogPassword.Text;

           
           
            if (AuthenticateUser(username, password, connectionString))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Interface.SelectedIndex = 3;
                // If the login is successful, you will be redirected to this section.
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            Interface.SelectedIndex = 0;
        }

        private void TextBox3_MouseDown_1(object sender, MouseEventArgs e)
        {//When the textbox is clicked, the informational message is deleted.
         //This operation is done with the MouseDown event.
            TextName1.Text = "";
        }

        private void TextBox4_MouseDown_1(object sender, MouseEventArgs e)
        {
            TextSurname1.Text = "";
        }

        private void TextBox13_MouseDown(object sender, MouseEventArgs e)
        {
            Textname3.Text = "";
        }

        private void TextBox12_MouseDown(object sender, MouseEventArgs e)
        {
            TextSurname3.Text = "";
        }
      

        private void TextBox11_MouseDown(object sender, MouseEventArgs e)
        {
            TextAddress3.Text = "";
        }

        private void TextBox6_MouseDown(object sender, MouseEventArgs e)
        {
            TextUsername4.Text = "";
        }

        private void TextBox5_MouseDown(object sender, MouseEventArgs e)
        {
            TextPassword4.Text = "";
        }
        private void TextBox7_MouseDown_1(object sender, MouseEventArgs e)
        {
            textAddress1.Text = "";
        }

        private void TextBox8_MouseDown_1(object sender, MouseEventArgs e)
        {
            TextUsername2.Text = "";
        }

        private void TextBox9_MouseDown_1(object sender, MouseEventArgs e)
        {
            TextPassword2.Text = "";
        }
        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TextLogUsername.Text = "";
        }
        private void TextBox18_MouseDown(object sender, MouseEventArgs e)
        {
            TextMail1.Text = "";
        }
        private void TextBox19_MouseDown(object sender, MouseEventArgs e)
        {
            TextUsername3.Text = "";
        }
        private void TextBox16_MouseDown(object sender, MouseEventArgs e)
        {
            TextPassword3.Text = "";
        }
        private void TextBox17_MouseDown(object sender, MouseEventArgs e)
        {
            TextRePassword.Text = "";

        }
        private void TextBox15_MouseDown(object sender, MouseEventArgs e)
        {
            TextCode.Text = "";
        }
        private void TextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            TextLogPassword.Text = "";
            TextLogPassword.PasswordChar = '*';
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            //Action that allows logging out of the application
            Application.Exit();
        }

        private void TextBox10_MouseDown(object sender, MouseEventArgs e)
        {
            TextMail2.Text = "";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Interface.SelectedIndex = 0;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Interface.SelectedIndex = 0;
        }
        private void Button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            //In this code block, the user's password is kept hidden or visible with the help of a button in the password entry field in the login section.

            if (TextLogPassword.PasswordChar == '*')
            {
                TextLogPassword.PasswordChar = '\0'; // show password

            }
            else if (TextLogPassword.PasswordChar == '\0')
            {
                TextLogPassword.PasswordChar = '*'; // hide password

            }
            else
            {
                TextLogPassword.PasswordChar = '*';
            }
        }
        private bool CheckUserNameExists(string username, string phoneNumber)
        {
            SqlConnection conn = new SqlConnection("Data Source=MUSTAFA-CAN;Initial Catalog=Login-Screen;Integrated Security=True;");
            {
                string query = "SELECT COUNT(*) FROM AccountInfo WHERE UserName = @UserName OR PhoneNumber = @PhoneNumber";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    conn.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        private void Button5_Click_1(object sender, EventArgs e)
        {
            //In this code block, the process of opening a new user account is performed by entering the required user information.

            string connectionString = "Data Source=Server Name;Initial Catalog=database Name;Integrated Security=True;";
            var username = TextUsername2.Text;
            string phoneNumber = MaskedTextPhoneNum1.Text;
            if (CheckUserNameExists(username, connectionString))
            {
                MessageBox.Show("There is an account with this username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string insertQuery = "INSERT INTO AccountInfo (Name, Surname, PhoneNumber, BirthOfDay, Gender, Address, UserName, Password, Email) " +
                                             "VALUES (@Name, @Surname, @PhoneNumber, @BirthOfDay, @Gender, @Address, @UserName, @Password, @Email)";
                        //Using the Microsoft SQL database, operations are carried out to determine which column in the table will be
                        //used to add information to the database.
                        SqlCommand cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@Name", TextName1.Text);
                        cmd.Parameters.AddWithValue("@Surname", TextSurname1.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", MaskedTextPhoneNum1.Text);
                        cmd.Parameters.AddWithValue("@BirthOfDay", MaskedTextBirtDay1.Text);
                        cmd.Parameters.AddWithValue("@Address", textAddress1.Text);
                        cmd.Parameters.AddWithValue("@UserName", TextUsername2.Text);
                        cmd.Parameters.AddWithValue("@Password", TextPassword2.Text);
                        cmd.Parameters.AddWithValue("@Email", TextMail1.Text);
                        /*
                         This piece of code loops through the checkListBox1.CheckedItems collection, which represents the items currently selected in a checkListBox1 control. 
                         This collection contains the items marked in the control.
                         */
                        string genderSelection = "";
                        foreach (object itemChecked in checkedListBox1.CheckedItems)
                        {
                            genderSelection += itemChecked.ToString() + ", ";
                        }
                        genderSelection = genderSelection.TrimEnd(',', ' ');
                        cmd.Parameters.AddWithValue("@Gender", genderSelection);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Your transaction cannot be completed right now, please try again.");
                }
            }

        }

        private void Button15_Click(object sender, EventArgs e)
        {
            //This code block was written to create a pop-up shortcut.
            if (panel8.Height == 240)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
            //The process is completed when the panels reach the specified length.
            //The first timer is for closing the panels, the second timer is for opening the panels.
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //timer interval values ​​are determined as 10 milliseconds in the process properties window.
            panel3.Height = panel3.Height - 10;
            if (panel3.Height == 80)
            {
                timer1.Stop();
            }
            panel4.Height = panel4.Height - 10;
            if (panel4.Height == 80)
            {
                timer1.Stop();
            }
            panel8.Height = panel8.Height - 10;
            if (panel8.Height == 80)
            {
                timer1.Stop();
            }
            panel10.Height = panel10.Height - 10;
            if (panel10.Height == 80)
            {
                timer1.Stop();
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            panel3.Height = panel3.Height + 10;
            if (panel3.Height == 240)
            {
                timer2.Stop();
            }
            panel4.Height = panel4.Height + 10;
            if (panel4.Height == 160)
            {
                timer2.Stop();
            }
            panel8.Height = panel8.Height + 10;
            if (panel8.Height == 240)
            {
                timer2.Stop();
            }
            panel10.Height = panel10.Height + 10;
            if (panel10.Height == 160)
            {
                timer2.Stop();
            }

        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Interface.SelectedIndex = 4;
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            if (panel3.Height == 240)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            if (panel4.Height == 160)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Interface.SelectedIndex = 0;
        }
        private string verificationCode;
        private void Button10_Click(object sender, EventArgs e)
        {/*
          Sending e-mail is performed in this code block.
          By entering the user's e-mail address, a random number between 100000 and 999999 is determined and
          sent to the e-mail received from the user.
          
          */

            Random random = new Random();
            verificationCode = random.Next(100000, 999999).ToString();

            MailMessage Message = new MailMessage();
            SmtpClient Client = new SmtpClient();
            Client.Credentials = new System.Net.NetworkCredential("xxxxxxxxxxx@gmail.com", "111111111111");
            /*
             Specifies the port number of the server to which the connection will be established via the SMTP client.
             In this particular case, port 465 is configured for a secure connection using SSL (Secure Sockets Layer).
             There are two common port numbers used to establish a secure connection to the Gmail SMTP server smtp.gmail.com:
             */
            Client.Port = 465;
            //A standard protocol is used to send emails, an SMTP (Simple Mail Transfer Protocol) server used for Google's Gmail service.
            Client.Host = "smtp.gmail.com";
            //This code is used to encrypt the message sent between the server and the client.
            Client.EnableSsl = true;
            Message.To.Add(TextMail2.Text);
            Message.From = new MailAddress("xxxxxxxxxx@gmail.com");
            Message.Subject = "Password Reset";
            Message.Body = $"Your verification code is {verificationCode}";

            try
            {
                Client.Send(Message);
                MessageBox.Show("Your verification code has been sent, please check your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email. Error: {ex.Message}");

            }

        }

        private void Button26_Click(object sender, EventArgs e)
        {
            //This block of code is for resetting the password.
            //If the code sent by the system is correct, the password is renewed.
            if (TextCode.Text == verificationCode)
            {
                MessageBox.Show("Verification successful.");
                Interface.SelectedIndex = 5;
            }
            else
            {
                MessageBox.Show("Invalid verification code.");
            }
        }

        private void Button25_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button27_Click(object sender, EventArgs e)
        {
            string newPassword = TextPassword3.Text;
            string confirmPassword = TextRePassword.Text;

            if (newPassword == confirmPassword)
            {
                UpdatePassword(newPassword);
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please try again.");
            }

        }
        private void UpdatePassword(string newPassword)
        {
            //In this code block, the user's password is updated.
            string connectionString = "Data Source=Server Name;Initial Catalog=Database Name;Integrated Security=True;";
            string username = TextUsername3.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE accountinfo SET password = @password WHERE username = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@password", newPassword);
                    command.Parameters.AddWithValue("@username", username);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password has been updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("The password could not be updated. User not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred, please try again ");
                    }
                }
            }
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            string genderSelection = "";
            foreach (object itemChecked in checkedListBox2.CheckedItems)
            {
                genderSelection += itemChecked.ToString() + ", ";
            }
            genderSelection = genderSelection.TrimEnd(',', ' ');

            string connectionString = "Data Source=MUSTAFA-CAN;Initial Catalog=Login-Screen;Integrated Security=True;";

            // Güncelleme sorgusu
            string updateQuery = "UPDATE AccountInfo SET Name=@Name, Surname=@Surname, PhoneNumber=@PhoneNumber, BirthOfDay=@BirthOfDay, Gender=@Gender, Address=@Address, Password=@Password, Email=@Email WHERE UserName=@UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@Name", Textname3.Text);
                        command.Parameters.AddWithValue("@Surname", TextSurname3.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", maskedTextPhoneNum2.Text);
                        command.Parameters.AddWithValue("@BirthOfDay", MaskedTextBirthDay3.Text);
                        command.Parameters.AddWithValue("@Gender", genderSelection);
                        command.Parameters.AddWithValue("@Address", TextAddress3.Text);
                        command.Parameters.AddWithValue("@UserName", TextUsername4.Text);
                        command.Parameters.AddWithValue("@Password", TextPassword4.Text);
                        command.Parameters.AddWithValue("@Email", TextMail3.Text);


                        int rowsAffected = command.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User information has been updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("An error occurred during the update.");
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error has occurred. Please try again later. " + ex.Message);
                }
                finally
                {

                    connection.Close();
                }
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            /*
             This code block is for deleting the user's information.
            When the deletion process occurs, the information is moved to a different table from the table where the actual records are kept.
             */
            string connectionString = "Data Source=MUSTAFA-CAN;Initial Catalog=Login-Screen;Integrated Security=True;";
            string password = textPassword5.Text;
            string deletionReason = ComboBoxrReason.SelectedItem.ToString();
            string username = TextUsername5.Text; // Kullanıcının kullanıcı adı

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //With the user information select query, all information is collected and only the information in a certain column is copied.
                    // Get user information from AccountInfo table
                    string selectQuery = "SELECT Name, Surname, Username, Password FROM AccountInfo WHERE Username = @Username AND Password = @Password";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@Username", username);
                    selectCommand.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        string surname = reader["Surname"].ToString();
                        string userPassword = reader["Password"].ToString();

                        reader.Close();
                        //For users who delete their information, only their username, password and information
                        //about why they want to delete are kept in a different table.
                        // Add information to DeleteAccount table
                        string insertQuery = "INSERT INTO DeleteAccount (Name, Surname, Username, Password, DeletionReason) VALUES (@Name, @Surname, @Username, @Password, @DeletionReason)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@Name", name);
                        insertCommand.Parameters.AddWithValue("@Surname", surname);
                        insertCommand.Parameters.AddWithValue("@Username", username);
                        insertCommand.Parameters.AddWithValue("@Password", userPassword);
                        insertCommand.Parameters.AddWithValue("@DeletionReason", deletionReason);

                        insertCommand.ExecuteNonQuery();

                        // Delete user from AccountInfo table
                        string deleteQuery = "DELETE FROM AccountInfo WHERE Username = @Username AND Password = @Password";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@Username", username);
                        deleteCommand.Parameters.AddWithValue("@Password", password);

                        deleteCommand.ExecuteNonQuery();

                        MessageBox.Show("Hesap başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            if (panel10.Height == 160)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
                
            
        
      
    


    


