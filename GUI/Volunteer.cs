using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace GUI
{
    public partial class Volunteer : Form
    {
        VolunteerBLL volunteerBLL = new VolunteerBLL();
        ServicBLL servicBLL = new ServicBLL();
        ServiceVolunteerBLL serviceVolunteerBLL = new ServiceVolunteerBLL();
        ArrangedRequestsBLL arrangedRequestsBLL = new ArrangedRequestsBLL();
        public Volunteer()
        {
            InitializeComponent();
            FillEx7("netivot");
        }
        public void FillEx7(string id)
        {
            int hoursthismonth;
            double averagethismonth;
            volunteerBLL.GetVolunteerHoursInfo(id, out hoursthismonth, out averagethismonth);

        }
        //1
        public void ChechHoursBtn_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();
            if (id.Length==9)
            {
                try
                {
                    int resteHours = servicBLL.MonthlyHoursRemaining(id);
                    resteHourslbl.Text = $"שעות שנותרו החודש:{resteHours}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid id(int id)");
            }
        }
        //2
        public void mostHoursBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text.Trim(), out int id))
            {
                try
                {
                    List<VolunteerDTO> l = serviceVolunteerBLL.VolunteersHaveMostHoursToDonateLeft(id);
                    ex7.DataSource = l.Select(f => new { f.FullName, f.IdVolunteer, f.Phone });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid id(int id)");
            }

        }
        //3
        public void ex3Btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdService.Text.Trim(), out int id))
            {
                try
                {
                    int v, a;
                    servicBLL.NumVolunteersForThisServiceAndApproved(id, out v, out a);
                    MessageBox.Show($"בשרות זה יש {v} מתנדבים ו-{a} בקשות מאושרות השנה.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID");
            }
        }
        //4
        public void Ex4Btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdService.Text.Trim(), out int idService))
            {
                try
                {
                    bool enoughHours = servicBLL.EnoughHoursDonated(idService);

                    if (enoughHours)
                    {
                        MessageBox.Show("יש מספיק שעות שנתרמו החודש לשירות זה.", "הצלחה");
                    }
                    else
                    {
                        MessageBox.Show("אין מספיק שעות שנתרמו החודש לשירות זה.", "אזהרה");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("אנא הזן מספר שירות תקין.", "שגיאה");
            }
        }
        //5
        public void ex5btn_Click(object sender, EventArgs e)
        {
            string id=txtIdService.Text.Trim();
            if (string.IsNullOrWhiteSpace(id) || id.Length != 9)
            {
                MessageBox.Show("שגיאה", "אנא הזיני תעודת זהות תקינה - 9 ספרות");
                return;
            }
            try
            {
                int numIdSVolunteerGive = servicBLL.howManyUniqueHelpDoVolunteerGive(id);
                MessageBox.Show($"המתנדב נותן {numIdSVolunteerGive} שירותים שאין מתנדבים אחרים שנותנים אותם.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("שגיטה"+ex.Message);
            }
        }


        //6
        public void ex6btn_Click(object sender, EventArgs e)
        {
            string id = txtId.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || id.Length != 9)
            {
                MessageBox.Show("אנא הזן תעודת זהות תקינה בת 9 ספרות.");
                return;
            }

            try
            {
                // Appel à la couche BLL
                List<NextVolunteeringDetailsDTO> results = arrangedRequestsBLL.getNextVolunteeringDetails(id);

                if (results.Count == 0)
                {
                    MessageBox.Show("אין בקשות עתידיות למתנדב זה.");
                }
                else
                {
                    // Construction du message
                    StringBuilder message = new StringBuilder();

                    foreach (var item in results)
                    {
                        message.AppendLine($"שם מבקש העזרה: {item.FullName}");
                        message.AppendLine($"תוכן הבקשה: {item.RequestContent}");
                        message.AppendLine($"טל המבקש: {item.Phone}");
                        message.AppendLine($"כתובת המבקש: {item.Address}");
                        message.AppendLine($"שם השירות: {item.NameService}");
                        message.AppendLine($"תאריך הבקשה: {item.DateRequest.ToShortDateString()}");

                        message.AppendLine("-----------------------------------");
                    }

                    // Affichage
                    MessageBox.Show(message.ToString(), "בקשות עתידיות למתנדב");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה: " + ex.Message);
            }
        }
    }
}
