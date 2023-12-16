using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace WPFResumeBuilder
{
    /// <summary>
    /// Interaction logic for ResumeBuilder.xaml
    /// </summary>
    public partial class ResumeBuilder : Window
    {
        Person person;
        public ResumeBuilder(Person person)
        {
            InitializeComponent();
            this.person = person;

            //display the user
            firstNameTextBox.Text = person.FirstName;
            lastNameTextBox.Text = person.LastName;
            titleTextBox.Text = person.Title;
            phoneNumberTextBox.Text = person.PhoneNumber;
            addressTextBox.Text = person.Address;
            languagesTextBox.Text = person.Languages;
            emailTextBox.Text = person.Email;
            

            aboutMeTextBox.Text = $"Passionate and detail-oriented {person.Title}, {person.Age}, with a strong foundation in building robust\n " +
                "and scalable applications. Proficient in multiple programming languages and frameworks, committed to\n " +
                "delivering high-quality code. Adept at collaborating with cross-functional teams to drive\n " +
                "project success. Eager to leverage my skills in a dynamic environment through the Resume Builder app\n " +
                "to empower individuals in crafting compelling professional narratives.";

            experienceTextBox.Text = $"As a {person.Title} in {person.City} at XYZ Tech Solutions, I played a pivotal role in crafting innovative \n" +
                "and efficient software solutions. Developed robust and scalable applications using \n" +
                "[Programming Languages/Frameworks]. Contributed to the design and implementation of key features.\n" +
                "Collaborated with stakeholders to gather and analyze requirements\n";

            educationTextBox.Text = $"During my {person.Education}, I acquired a solid foundation in theoretical and practical\n" +
            " aspects of computer science. The curriculum covered a diverse range of subjects, including algorithms,\n" +
            " data structures, software engineering principles, and database management.During my\n" +
            $"{person.Education} I acquired a solid foundation in theoretical and practical aspects\n" +
            "of computer science. The curriculum covered a diverse range of subjects, including algorithms,\n" +
            "data structures, software engineering principles, and database management.";

            projectsTextBox.Text = $"So, one of the cool projects I worked on was a Smart Home Automation System. We designed \n" +
                "and implemented a system that allowed users to control various aspects of their home, like lights, \n" +
                "thermostat and security cameras, all from a centralized mobile app. My role involved developing the \n" +
                "backend API, integrating it with IoT devices, and ensuring seamless. ";

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                using (PdfDocument document = new PdfDocument())
                {

                    PdfPage page = document.AddPage();

                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    AddContentToPdf(gfx, page);

                    string fileName = "Resume.pdf";
                    string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                    document.Save(filePath);


                }

                MessageBox.Show("PDF Saved Successfully!");

            }

            catch (Exception ex){
                MessageBox.Show($"Error: {ex.Message}");
            
            }

            person.FirstName = firstNameTextBox.Text;
            person.LastName = lastNameTextBox.Text;
            person.Title = titleTextBox.Text;
            person.PhoneNumber = phoneNumberTextBox.Text;
            person.Address = addressTextBox.Text;
            person.Languages = languagesTextBox.Text;
            person.Email = emailTextBox.Text;
            

            PersonDBHandler db = PersonDBHandler.Instance;
            db.UpdatePerson(person);
            Close();


        }

        private void AddContentToPdf(XGraphics gfx, PdfPage page) {

            double redSection = 180;

            XRect redSectionRect = new XRect(0, 0, redSection, page.Height); 
            var gradientBrush = new XLinearGradientBrush(redSectionRect, XColors.White, XColors.Red, XLinearGradientMode.Vertical); 
            gfx.DrawRectangle(gradientBrush, redSectionRect);
            gfx.DrawLine(XPens.Black, redSection, 0, redSection, page.Height);

            XRect whiteRect = new XRect(redSection, 0, page.Width - redSection, page.Height); 
            gfx.DrawRectangle(XBrushes.White, whiteRect);


            XFont nameFont = new XFont("Arial", 30);
            XFont titleFont = new XFont("Arial", 20);
            XFont categoriesFont = new XFont("Arial", 9);
            XFont categoriesTitle = new XFont("Arial", 12, XFontStyleEx.Underline);
            XFont smallerCategoriesText = new XFont("Arial", 9);
            XFont smallerCategoriesTitle = new XFont("Arial", 10, XFontStyleEx.Underline);

            gfx.DrawString($"{firstNameTextBox.Text}" + " " + $"{lastNameTextBox.Text}", nameFont, XBrushes.Black, new XRect(0, 50, page.Width, page.Height),XStringFormats.TopCenter);
            gfx.DrawString($"{titleTextBox.Text}", titleFont, XBrushes.Black, new XRect(0, 85, page.Width, page.Height), XStringFormats.TopCenter);

            XRect aboutMeRect = new XRect(redSection + 10, 170 + titleFont.Height, page.Width - redSection - 10, page.Height);
            XTextFormatter tf = new XTextFormatter(gfx);

            tf.DrawString($"{aboutMeTextBox.Text}", categoriesFont, XBrushes.Black, aboutMeRect, XStringFormats.TopLeft);

            XRect experienceRect = new XRect(190, 300 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf1 = new XTextFormatter(gfx);

            tf1.DrawString($"{experienceTextBox.Text}", categoriesFont, XBrushes.Black, experienceRect, XStringFormats.TopLeft);

            XRect educationRect = new XRect(190, 420 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf2 = new XTextFormatter(gfx);

            tf2.DrawString($"{educationTextBox.Text}", categoriesFont, XBrushes.Black, educationRect, XStringFormats.TopLeft);

            
            XRect projectsRect = new XRect(190, 600 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf3 = new XTextFormatter(gfx);

            tf3.DrawString($"{projectsTextBox.Text}", categoriesFont, XBrushes.Black, projectsRect, XStringFormats.TopLeft);

            XRect aboutMeTextRect = new XRect(190, 140 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf4 = new XTextFormatter(gfx);

            tf4.DrawString($"ABOUT ME", categoriesTitle, XBrushes.IndianRed, aboutMeTextRect, XStringFormats.TopLeft);

            XRect experienceTextRect = new XRect(190, 270 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf5 = new XTextFormatter(gfx);

            tf5.DrawString($"EXPERIENCE", categoriesTitle, XBrushes.IndianRed, experienceTextRect, XStringFormats.TopLeft);

            XRect educationTextRect = new XRect(190, 390 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf6 = new XTextFormatter(gfx);

            tf6.DrawString($"EDUCATION", categoriesTitle, XBrushes.IndianRed, educationTextRect, XStringFormats.TopLeft);

            XRect projectsTextRect = new XRect(190, 570 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf7 = new XTextFormatter(gfx);

            tf7.DrawString($"PROJECTS", categoriesTitle, XBrushes.IndianRed, projectsTextRect, XStringFormats.TopLeft);

            XRect contactTextRect = new XRect(60, 140 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf8 = new XTextFormatter(gfx);

            tf8.DrawString($"CONTACT ME", smallerCategoriesTitle, XBrushes.WhiteSmoke, contactTextRect, XStringFormats.TopLeft);

            XRect contactRect1 = new XRect(70, 160 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf9 = new XTextFormatter(gfx);

            tf9.DrawString($"{phoneNumberTextBox.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, contactRect1, XStringFormats.TopLeft);

            XRect contactRect2 = new XRect(70, 175 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf10 = new XTextFormatter(gfx);

            tf10.DrawString($"{addressTextBox.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, contactRect2, XStringFormats.TopLeft);

            XRect contactRect3 = new XRect(70, 190 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf11 = new XTextFormatter(gfx);

            tf11.DrawString($"{emailTextBox.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, contactRect3, XStringFormats.TopLeft);

            XRect socialProfileTextRect = new XRect(60, 270 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf12 = new XTextFormatter(gfx);

            tf12.DrawString($"SOCIAL PROFILE", smallerCategoriesTitle, XBrushes.WhiteSmoke, socialProfileTextRect, XStringFormats.TopLeft);

            XRect socialProfileRect1 = new XRect(70, 290 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf13 = new XTextFormatter(gfx);

            tf13.DrawString($"{socialTextBox.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, socialProfileRect1, XStringFormats.TopLeft);

            XRect socialProfileRect2 = new XRect(70, 305 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf14 = new XTextFormatter(gfx);

            tf14.DrawString($"{socialTextBox2.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, socialProfileRect2, XStringFormats.TopLeft);

            XRect socialProfileRect3 = new XRect(70, 320 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf15 = new XTextFormatter(gfx);

            tf15.DrawString($"{socialTextBox3.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, socialProfileRect3, XStringFormats.TopLeft);

            XRect socialProfileRect4 = new XRect(70, 335 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf16 = new XTextFormatter(gfx);

            tf16.DrawString($"{socialTextBox4.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, socialProfileRect4, XStringFormats.TopLeft);

            XRect otherInfoTextRect = new XRect(60, 390 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf17 = new XTextFormatter(gfx);

            tf17.DrawString($"OTHER INFO", smallerCategoriesTitle, XBrushes.WhiteSmoke, otherInfoTextRect, XStringFormats.TopLeft);

            XRect otherInfoRectText = new XRect(70, 410 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf18 = new XTextFormatter(gfx);

            tf18.DrawString($"{otherInfoTextBox.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, otherInfoRectText, XStringFormats.TopLeft);

            XRect languagesTextRect = new XRect(60, 500 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf19 = new XTextFormatter(gfx);

            tf19.DrawString($"LANGUAGES", smallerCategoriesTitle, XBrushes.WhiteSmoke, languagesTextRect, XStringFormats.TopLeft);

            XRect languagesRectText = new XRect(70, 520 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf20 = new XTextFormatter(gfx);

            tf20.DrawString($"{languagesTextBox.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, languagesRectText, XStringFormats.TopLeft);

            XRect interestTextRect = new XRect(60, 570 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf21 = new XTextFormatter(gfx);

            tf21.DrawString($"INTEREST", smallerCategoriesTitle, XBrushes.WhiteSmoke, interestTextRect, XStringFormats.TopLeft);

            XRect interestRectText = new XRect(70, 590 + titleFont.Height, page.Width, page.Height);
            XTextFormatter tf22 = new XTextFormatter(gfx);

            tf22.DrawString($"{interestTextBox.Text}", smallerCategoriesText, XBrushes.WhiteSmoke, interestRectText, XStringFormats.TopLeft);

            
        }
    }
}
