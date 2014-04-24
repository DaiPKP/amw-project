using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AmwayMeetingSubsidy.Admin
{
    public partial class RegisterRoom : System.Web.UI.Page
    {
        Connection con = new Connection();
        Controller func = new Controller();
        struct Distributor
        {
            public int x_ADA_ID;
            public string x_Distributor_Name;
            public string x_Level;
            public int ADA_ID
            {
                get
                {
                    return x_ADA_ID;
                }
                set 
                {
                    x_ADA_ID = value;
                }
            }
            public string Distributor_Name
            {
                get
                {
                    return x_Distributor_Name;
                }
                set
                {
                    x_Distributor_Name = value;
                }
            }
            public string Level
            {
                get
                {
                    return x_Level;
                }
                set
                {
                    x_Level = value;
                }
            }
        }
        static Distributor[] dist;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.bt_ok.Visible = false;
            //this.bt_error.Visible = false;
        }
        public void MessageBox(string message)
        {
            string scriptstring = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertscript", scriptstring, true);
        }
        protected void bt_check_organizer_Click(object sender, ImageClickEventArgs e)
        {            
            check_distributor(txt_organizer_id.Text.Trim(),ddl_room_type.SelectedItem.Text.Trim(), txt_organizer_name, txt_organizer_level, bt_ok, bt_error);
        }
        public void check_distributor(string ADA_ID,string Room_Type,TextBox Name, TextBox Level,ImageButton Ok, ImageButton Error)
        {
            DataTable table = new DataTable();
            table = con.ExcuteQuery("v_LoadQuota", "[ADA ID]",ADA_ID);
            if (table != null)
            {
                Name.Text = table.Rows[0]["Distributor Name"].ToString();
                Level.Text = table.Rows[0]["Level"].ToString();
                if (!Room_Type.Equals("Chose Meeting Room Type"))
                {
                    int quota = int.Parse(table.Rows[0][Room_Type].ToString());                  
                    if (quota <= 0)
                    {
                        Ok.Visible = false;
                        Error.Visible = true;
                    }
                    else
                    {
                        Error.Visible = false;
                        Ok.Visible = true;
                    }
                }
            }
        }
        public void CalculatePayment(TextBox Amway, TextBox Dist, TextBox Total)
        {
            if (ddl_meeting_type.SelectedValue.Trim().Equals("SU"))
            {
                int amway, distributor, total, max;
                total = int.Parse(txt_spend_to_rent.Text.Trim());
                max = func.GetMaxPayment(ddl_room_type.SelectedValue.Trim(), dist[0].Level.Trim());
                amway = total * 8 / 10;

                if (amway < max)
                {
                    Amway.Text = amway.ToString();
                    distributor = total - amway;
                }
                else
                {
                    Amway.Text = max.ToString();
                    distributor = total - max;
                }
                Dist.Text = distributor.ToString();
                Total.Text = total.ToString();
            }
            else
            {
                int total = int.Parse(txt_spend_to_rent.Text.Trim());
                Amway.Text = "0";
                Dist.Text = total.ToString();
                Total.Text = total.ToString();
            }

        }
        public bool checkfill(TextBox ID, TextBox Name, TextBox Level)
        {
            if (ID.Text.Trim().Equals("") || Name.Text.Equals("") || Level.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checkquota(ImageButton ok, ImageButton error)
        {
            if (ok.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void hidden_panel()
        {
            this.combined_1.Visible = false;
            this.combined_2.Visible = false;
            this.combined_3.Visible = false;
            this.combined_4.Visible = false;
            this.combined_5.Visible = false;
            this.Info.Visible = false;
            this.bt_combined1_ok.Visible = false;
            this.bt_combined2_ok1.Visible = false;
            this.bt_combined2_ok2.Visible = false;
            this.bt_combined3_ok1.Visible = false;
            this.bt_combined3_ok2.Visible = false;
            this.bt_combined3_ok3.Visible = false;
            this.bt_combined4_ok1.Visible = false;
            this.bt_combined4_ok2.Visible = false;
            this.bt_combined4_ok3.Visible = false;
            this.bt_combined4_ok4.Visible = false;
            this.bt_combined5_ok1.Visible = false;
            this.bt_combined5_ok2.Visible = false;
            this.bt_combined5_ok3.Visible = false;
            this.bt_combined5_ok4.Visible = false;
            this.bt_combined5_ok5.Visible = false;
        }

        protected void bt_process_Click(object sender, ImageClickEventArgs e)
        {
          
            if (!checkfill(txt_organizer_id,txt_organizer_name,txt_organizer_level))
            {
                MessageBox("Please, Input full information of organizer");
                return;
            }
            if(con.ExcuteQuery("Distributor","ADA_ID",txt_organizer_id.Text.Trim(),"Active").Rows.Count>0)
            {
                MessageBox("You can not register meeting because supervisor denied you, please contact to supervisor...");
                return;
            }
            int temp = Int32.Parse(this.ddl_rule_level.SelectedValue.Trim());
            switch (temp)
            {
                case 0:
                    {
                        hidden_panel();
                        this.combined_1.Visible = true;
                        break;
                    }

                case 2:
                    {
                        hidden_panel();
                        this.combined_2.Visible = true;
                        break;
                    }
                case 3:
                    {
                        hidden_panel();
                        this.combined_3.Visible = true;
                        break;
                    }
                case 4:
                    {
                        hidden_panel();
                        this.combined_4.Visible = true;
                        break;
                    }
                case 5:
                    {
                        hidden_panel();
                        this.combined_5.Visible = true;
                        break;
                    }
            }
        }

        protected void ddl_rule_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidden_panel();
            if (ddl_meeting_type.SelectedValue.Trim().Equals("OU") || ddl_meeting_type.SelectedValue.Trim().Equals("OV"))
            {
                this.Info.Visible = true;
            }
        }

        protected void ddl_room_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidden_panel();
            if (ddl_meeting_type.SelectedValue.Trim().Equals("OU") || ddl_meeting_type.SelectedValue.Trim().Equals("OV"))
            {
                this.Info.Visible = true;
            }
        }

        protected void bt_combined1_check_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(this.txt_combined1_id.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined1_name, txt_combined1_level, bt_combined1_ok, bt_combined1_error);
        }

        protected void bt_combined2_check1_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined2_id1.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined2_name1, txt_combined2_level1, bt_combined2_ok1, bt_combined2_error2);
        }

        protected void bt_combined2_check2_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined2_id2.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined2_name2, txt_combined2_level2, bt_combined2_ok2, bt_combined2_error2);
        }

        protected void bt_combined3_check1_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined3_id1.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined3_name1, txt_combined3_level1, bt_combined3_ok1, bt_combined3_error1);
        }

        protected void bt_combined3_check2_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined3_id2.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined3_name2, txt_combined3_level2, bt_combined3_ok2, bt_combined3_error2);
        }

        protected void bt_combined3_check3_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined3_id3.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined3_name3, txt_combined3_level3, bt_combined3_ok3, bt_combined3_error3);
        }

        protected void bt_combined4_check1_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined4_id1.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined4_name1, txt_combined4_level1, bt_combined4_ok1, bt_combined4_error1);
        }

        protected void bt_combined4_check2_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined4_id2.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined4_name2, txt_combined4_level2, bt_combined4_ok2, bt_combined4_error2);
        }

        protected void bt_combined4_check3_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined4_id3.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined4_name3, txt_combined4_level3, bt_combined4_ok3, bt_combined4_error3);
        }

        protected void bt_combined4_check4_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined4_id4.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined4_name4, txt_combined4_level4, bt_combined4_ok4, bt_combined4_error4);
        }

        protected void bt_combined5_check1_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined5_id1.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined5_name1, txt_combined5_level1, bt_combined5_ok1,bt_combined5_error1);
        }

        protected void bt_combined5_check2_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined5_id2.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined5_name2, txt_combined5_level2, bt_combined5_ok2, bt_combined5_error2);
        }

        protected void bt_combined5_check3_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined5_id3.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined5_level3, txt_combined5_level3, bt_combined5_ok3, bt_combined5_error3);
        }

        protected void bt_combined5_check4_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined5_id4.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined5_name4, txt_combined5_level4, bt_combined5_ok4, bt_combined5_error4);
        }

        protected void bt_combined5_check5_Click(object sender, ImageClickEventArgs e)
        {
            check_distributor(txt_combined5_id5.Text.Trim(), ddl_room_type.SelectedItem.Text.Trim(), txt_combined5_name5, txt_combined5_level5, bt_combined5_ok5, bt_combined5_error5);
        }

        protected void bt_combined1_update_Click(object sender, ImageClickEventArgs e)
        {
            if (!checkfill(txt_combined1_id, txt_combined1_name, txt_combined1_level))
            {
                MessageBox("Please, Input full information");
                return;
            }
            if(!checkquota(bt_combined1_ok,bt_combined1_error))
            {
                MessageBox("Distributor expire quota, click button if you want to borrow quota");
                return;
            }
            dist = new Distributor[1];
            dist[0].ADA_ID = int.Parse(this.txt_combined1_id.Text.Trim());
            dist[0].Distributor_Name = this.txt_combined1_name.Text.ToString();
            dist[0].Level = this.txt_combined1_level.Text.ToString();
            MessageBox("Update Completed");
            this.Info.Visible = true;
        }

        protected void bt_combined2_update_Click(object sender, ImageClickEventArgs e)
        {
            if (!checkfill(txt_combined2_id1, txt_combined2_name1, txt_combined2_level1))
            {
                MessageBox("Please, Input full information of Distributor 1");
                return;
            }
            if (!checkquota(bt_combined2_ok1, bt_combined2_error1))
            {
                MessageBox("Distributor 1 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined2_id2, txt_combined2_name2, txt_combined2_level2))
            {
                MessageBox("Please, Input full information of Distributor 2");
                return;
            }
            if (!checkquota(bt_combined2_ok2, bt_combined2_error2))
            {
                MessageBox("Distributor 2 expire quota, click button if you want to borrow quota");
                return;
            }
            dist = new Distributor[2];
            dist[0].ADA_ID=int.Parse(txt_combined2_id1.Text.Trim());
            dist[0].Distributor_Name = txt_combined2_name1.Text.ToString();
            dist[0].Level = txt_combined2_level1.Text.ToString();
            dist[1].ADA_ID = int.Parse(txt_combined2_id2.Text.Trim());
            dist[1].Distributor_Name = txt_combined2_name2.Text.ToString();
            dist[1].Level = txt_combined2_level2.Text.ToString();
            MessageBox("Update Completed");
            this.Info.Visible = true;
        }

        protected void bt_combined3_update_Click(object sender, ImageClickEventArgs e)
        {
            if (!checkfill(txt_combined3_id1, txt_combined3_name1, txt_combined3_level1))
            {
                MessageBox("Please, Input full information of Distributor 1");
                return;
            }
            if (!checkquota(bt_combined3_ok1, bt_combined3_error1))
            {
                MessageBox("Distributor 1 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined3_id2, txt_combined3_name2, txt_combined3_level2))
            {
                MessageBox("Please, Input full information of Distributor 2");
                return;
            }
            if (!checkquota(bt_combined3_ok2, bt_combined3_error2))
            {
                MessageBox("Distributor 2 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined3_id3, txt_combined3_name3, txt_combined3_level3))
            {
                MessageBox("Please, Input full information of Distributor 3");
                return;
            }
            if (!checkquota(bt_combined3_ok3, bt_combined3_error3))
            {
                MessageBox("Distributor 3 expire quota, click button if you want to borrow quota");
                return;
            }
            dist = new Distributor[3];
            dist[0].ADA_ID = int.Parse(txt_combined3_id1.Text.Trim());
            dist[0].Distributor_Name = txt_combined3_name1.Text.ToString();
            dist[0].Level = txt_combined3_level1.Text.ToString();
            dist[1].ADA_ID = int.Parse(txt_combined3_id2.Text.Trim());
            dist[1].Distributor_Name = txt_combined3_name2.Text.ToString();
            dist[1].Level = txt_combined3_level2.Text.ToString();
            dist[2].ADA_ID = int.Parse(txt_combined3_id3.Text.Trim());
            dist[2].Distributor_Name = txt_combined3_name3.Text.ToString();
            dist[2].Level = txt_combined3_level3.Text.ToString();
            MessageBox("Update Completed");
            this.Info.Visible = true;
        }

        protected void bt_combined4_update_Click(object sender, ImageClickEventArgs e)
        {
            if (!checkfill(txt_combined4_id1, txt_combined4_name1, txt_combined4_level1))
            {
                MessageBox("Please, Input full information of Distributor 1");
                return;
            }
            if (!checkquota(bt_combined4_ok1, bt_combined4_error1))
            {
                MessageBox("Distributor 1 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined4_id2, txt_combined4_name2, txt_combined4_level2))
            {
                MessageBox("Please, Input full information of Distributor 2");
                return;
            }
            if (!checkquota(bt_combined4_ok2, bt_combined4_error2))
            {
                MessageBox("Distributor 2 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined4_id3, txt_combined4_name3, txt_combined4_level3))
            {
                MessageBox("Please, Input full information of Distributor 3");
                return;
            }
            if (!checkquota(bt_combined4_ok3, bt_combined4_error3))
            {
                MessageBox("Distributor 3 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined4_id4, txt_combined4_name4, txt_combined4_level4))
            {
                MessageBox("Please, Input full information of Distributor 4");
                return;
            }
            if (!checkquota(bt_combined4_ok4, bt_combined4_error4))
            {
                MessageBox("Distributor 4 expire quota, click button if you want to borrow quota");
                return;
            }
            dist = new Distributor[4];
            dist[0].ADA_ID = int.Parse(txt_combined4_id1.Text.Trim());
            dist[0].Distributor_Name = txt_combined4_name1.Text.ToString();
            dist[0].Level = txt_combined4_level1.Text.ToString();
            dist[1].ADA_ID = int.Parse(txt_combined4_id2.Text.Trim());
            dist[1].Distributor_Name = txt_combined4_name2.Text.ToString();
            dist[1].Level = txt_combined4_level2.Text.ToString();
            dist[2].ADA_ID = int.Parse(txt_combined4_id3.Text.Trim());
            dist[2].Distributor_Name = txt_combined4_name3.Text.ToString();
            dist[2].Level = txt_combined4_level3.Text.ToString();
            dist[3].ADA_ID = int.Parse(txt_combined4_id4.Text.Trim());
            dist[3].Distributor_Name = txt_combined4_name4.Text.ToString();
            dist[3].Level = txt_combined4_level4.Text.ToString();
            MessageBox("Update Completed");
            this.Info.Visible = true;
        }

        protected void bt_combine5_update_Click(object sender, ImageClickEventArgs e)
        {
            if (!checkfill(txt_combined5_id1, txt_combined5_name1, txt_combined5_level1))
            {
                MessageBox("Please, Input full information of Distributor 1");
                return;
            }
            if (!checkquota(bt_combined5_ok1, bt_combined5_error1))
            {
                MessageBox("Distributor 1 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined5_id2, txt_combined5_name2, txt_combined5_level2))
            {
                MessageBox("Please, Input full information of Distributor 2");
                return;
            }
            if (!checkquota(bt_combined5_ok2, bt_combined5_error2))
            {
                MessageBox("Distributor 2 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined5_id3, txt_combined5_name3, txt_combined5_level3))
            {
                MessageBox("Please, Input full information of Distributor 3");
                return;
            }
            if (!checkquota(bt_combined5_ok3, bt_combined5_error3))
            {
                MessageBox("Distributor 3 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined5_id4, txt_combined5_name4, txt_combined5_level4))
            {
                MessageBox("Please, Input full information of Distributor 4");
                return;
            }
            if (!checkquota(bt_combined5_ok4, bt_combined5_error4))
            {
                MessageBox("Distributor 4 expire quota, click button if you want to borrow quota");
                return;
            }
            if (!checkfill(txt_combined5_id5, txt_combined5_name5, txt_combined5_level5))
            {
                MessageBox("Please, Input full information of Distributor 5");
                return;
            }
            if (!checkquota(bt_combined5_ok5, bt_combined5_error5))
            {
                MessageBox("Distributor 5 expire quota, click button if you want to borrow quota");
                return;
            }
            dist = new Distributor[5];
            dist[0].ADA_ID = int.Parse(txt_combined5_id1.Text.Trim());
            dist[0].Distributor_Name = txt_combined5_name1.Text.ToString();
            dist[0].Level = txt_combined5_level1.Text.ToString();
            dist[1].ADA_ID = int.Parse(txt_combined5_id2.Text.Trim());
            dist[1].Distributor_Name = txt_combined5_name2.Text.ToString();
            dist[1].Level = txt_combined5_level2.Text.ToString();
            dist[2].ADA_ID = int.Parse(txt_combined5_id3.Text.Trim());
            dist[2].Distributor_Name = txt_combined5_name3.Text.ToString();
            dist[2].Level = txt_combined5_level3.Text.ToString();
            dist[3].ADA_ID = int.Parse(txt_combined5_id4.Text.Trim());
            dist[3].Distributor_Name = txt_combined5_name4.Text.ToString();
            dist[3].Level = txt_combined5_level4.Text.ToString();
            dist[4].ADA_ID = int.Parse(txt_combined5_id5.Text.Trim());
            dist[4].Distributor_Name = txt_combined5_name5.Text.ToString();
            dist[4].Level = txt_combined5_level5.Text.ToString();
            MessageBox("Update Completed");
            this.Info.Visible = true;
        }

        protected void bt_register_Click(object sender, ImageClickEventArgs e)
        {
            string status_1;
            string status_2;
            string Invoice_Code = func.GenerateInvoiceCode(ddl_meeting_type.SelectedValue.Trim());
            CalculatePayment(txt_amway_pay, txt_dist_pay, txt_spend_to_rent);
            if (txt_meeting_date.Text.Trim().Equals("") || txt_invite_date.Text.Trim().Equals(""))
            {
                MessageBox("Please, Select Meeting Date and Invitetation date");
                return;
            }

            DateTime Meeting_Date = Convert.ToDateTime(this.txt_meeting_date.Text);
            DateTime Date_Invite = Convert.ToDateTime(this.txt_invite_date.Text);
            if (Meeting_Date < Date_Invite)
            {
                MessageBox("Please, Invitetation before meeting");
                return;
            }
            TimeSpan time;
            TimeSpan.TryParse(txt_start_time_hh.Text + ":" + txt_start_time_mm.Text, out time);
            DateTime Start_Time = Meeting_Date.Add(time);
            TimeSpan.TryParse(txt_end_time_hh.Text + ":" + txt_end_time_mm.Text,out time);
            DateTime End_Time = Meeting_Date.Add(time);
            if (Start_Time >= End_Time)
            {
                MessageBox("Giờ kết thúc phải lớn hơn giờ bắt đầu");
                return;
            }
            if (txt_meeting_address.Text.Trim().Equals(""))
            {
                MessageBox("Please Input meeting address !!!");
                return;
            }
            if (ddl_meeting_type.SelectedValue.Trim().Equals("SU") || ddl_meeting_type.SelectedValue.Trim().Equals("AV"))
            {
                int temp = dist[0].ADA_ID;
                for(int i=1;i<dist.Length;i++)
                {
                    if (dist[i].ADA_ID == temp)
                    {
                        MessageBox("Distributor combined have to different");
                        return;
                    }
                }
                InfoRegister info = new InfoRegister(ddl_meeting_type.SelectedValue.Trim(), Invoice_Code, int.Parse(txt_organizer_id.Text.Trim()), txt_organizer_name.Text.Trim(), txt_organizer_level.Text.Trim(), ddl_room_type.SelectedValue.Trim(), txt_meeting_name.Text.Trim(), int.Parse(txt_number_user.Text.Trim()), txt_meeting_address.Text.Trim(), ddl_city.SelectedValue.Trim(), Meeting_Date, Start_Time, End_Time, int.Parse(txt_amway_pay.Text.Trim()), int.Parse(txt_dist_pay.Text.Trim()), int.Parse(txt_spend_to_rent.Text.Trim()), ddl_payment.SelectedItem.Text.Trim(), ddl_invitation_paper.SelectedItem.Text.Trim(), ddl_slogan.SelectedItem.Text.Trim(), txt_how_to_invite.Text.Trim(), Date_Invite, ddl_water.SelectedItem.Text.Trim(), int.Parse(txt_water_price.Text.Trim()), ddl_food.SelectedItem.Text.Trim(), int.Parse(txt_food_price.Text.Trim()), int.Parse(txt_ADA_ID_speaker1.Text.Trim()), txt_speaker1_name.Text.Trim(), txt_speaker1_level.Text.Trim(), txt_speaker1_content.Text.Trim(), int.Parse(txt_ADA_ID_speaker2.Text.Trim()), txt_speaker2_name.Text.Trim(), txt_speaker2_level.Text.Trim(), txt_speaker2_content.Text.Trim());
                status_1 = func.Register_Meeting_Room(info);
                if (status_1.Equals("Register Success"))
                {
                    foreach (Distributor d in dist)
                    {
                        InfoRegister info_1 = new InfoRegister(Invoice_Code, d.ADA_ID, d.Distributor_Name.Trim(), d.Level.Trim(), ddl_room_type.SelectedValue.Trim());
                        status_2 = func.Insert_Provider_Quota(info_1);
                    }
                }
                MessageBox(status_1);
                hidden_panel();
            }
            else
            {
                InfoRegister info = new InfoRegister(ddl_meeting_type.SelectedValue.Trim(), Invoice_Code, int.Parse(txt_organizer_id.Text.Trim()), txt_organizer_name.Text.Trim(), txt_organizer_level.Text.Trim(), ddl_room_type.SelectedValue.Trim(), txt_meeting_name.Text.Trim(), int.Parse(txt_number_user.Text.Trim()), txt_meeting_address.Text.Trim(), ddl_city.SelectedValue.Trim(), Meeting_Date, Start_Time, End_Time, int.Parse(txt_amway_pay.Text.Trim()), int.Parse(txt_dist_pay.Text.Trim()), int.Parse(txt_spend_to_rent.Text.Trim()), ddl_payment.SelectedItem.Text.Trim(), ddl_invitation_paper.SelectedItem.Text.Trim(), ddl_slogan.SelectedItem.Text.Trim(), txt_how_to_invite.Text.Trim(), Date_Invite, ddl_water.SelectedItem.Text.Trim(), int.Parse(txt_water_price.Text.Trim()), ddl_food.SelectedItem.Text.Trim(), int.Parse(txt_food_price.Text.Trim()), int.Parse(txt_ADA_ID_speaker1.Text.Trim()), txt_speaker1_name.Text.Trim(), txt_speaker1_level.Text.Trim(), txt_speaker1_content.Text.Trim(), int.Parse(txt_ADA_ID_speaker2.Text.Trim()), txt_speaker2_name.Text.Trim(), txt_speaker2_level.Text.Trim(), txt_speaker2_content.Text.Trim());
                status_1 = func.Register_Meeting_Room(info);
                MessageBox(status_1);
                hidden_panel();
            }
            
        }      

        protected void ddl_meeting_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_meeting_type.SelectedValue.Trim().Equals("OU") || ddl_meeting_type.SelectedValue.Trim().Equals("OV"))
            {
                this.Info.Visible = true;
                this.bt_process.Visible = false;
            }
            else
            {
                this.Info.Visible = false;
                this.bt_process.Visible = true;
            }
        }
        public static void Redirect(string url, string target, string windowFeatures)
        {
            HttpContext context = HttpContext.Current;

            if ((String.IsNullOrEmpty(target) ||
                target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&
                String.IsNullOrEmpty(windowFeatures))
            {

                context.Response.Redirect(url);
            }
            else
            {
                Page page = (Page)context.Handler;
                if (page == null)
                {
                    throw new InvalidOperationException(
                        "Cannot redirect to new window outside Page context.");
                }
                url = page.ResolveClientUrl(url);

                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }

                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page,
                    typeof(Page),
                    "Redirect",
                    script,
                    true);
            }
        }

        protected void bt_error_Click(object sender, ImageClickEventArgs e)
        {
            Redirect("../admin/BorrowQuota.aspx", "_blank", "menubar=0,width=1024,height=800");
        }        
    }
}