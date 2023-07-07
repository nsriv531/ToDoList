using System;
using System.Windows.Forms;
using System.Drawing;


namespace ToDoListAlpha
{
    public partial class Form1 : Form
    {
        private Label taskLabel;

        public Form1()
        {
            InitializeComponent();

            tabControl1.TabPages[0].Text = "Input Tasks"; // Set the text for the first tab
            tabControl1.TabPages[1].Text = "Find Tasks"; // Set the text for the second tab

            Button addButton = new Button();
            addButton.Text = "Add Task";
            addButton.Location = new System.Drawing.Point(10, 10);
            addButton.Click += addButton_Click;

            tabPage1.Controls.Add(addButton); // Add the button to the first tab page

            taskLabel = new Label();
            taskLabel.AutoSize = true;
            taskLabel.Location = new System.Drawing.Point(10, 40);
            tabPage1.Controls.Add(taskLabel); // Add the label to the first tab page
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string userInput = InputBox("Enter a task:", "Add Task");
            if (!string.IsNullOrEmpty(userInput))
            {
                taskLabel.Text = userInput; // Display the entered text in the label on the first tab page
                tabControl1.SelectedIndex = 0; // Switch to the first tab page
            }
        }

        private string InputBox(string prompt, string title)
        {
            Form inputForm = new Form();
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.Width = 300;

            Label promptLabel = new Label();
            promptLabel.Text = prompt;
            promptLabel.Location = new Point(10, 10);
            promptLabel.AutoSize = true;

            TextBox taskTextBox = new TextBox();
            taskTextBox.Location = new Point(10, promptLabel.Bottom + 10);
            taskTextBox.Width = inputForm.Width - 40;

            Label personLabel = new Label();
            personLabel.Text = "Enter Person Name:";
            personLabel.Location = new Point(10, taskTextBox.Bottom + 10);
            personLabel.AutoSize = true;

            TextBox personTextBox = new TextBox();
            personTextBox.Location = new Point(10, personLabel.Bottom + 10);
            personTextBox.Width = inputForm.Width - 40;

            Label dateLabel = new Label();
            dateLabel.Text = "Enter Initial Date:";
            dateLabel.Location = new Point(10, personTextBox.Bottom + 10);
            dateLabel.AutoSize = true;

            TextBox dateTextBox = new TextBox();
            dateTextBox.Location = new Point(10, dateLabel.Bottom + 10);
            dateTextBox.Width = inputForm.Width - 40;

            Label frequencyLabel = new Label();
            frequencyLabel.Text = "Enter Frequency:";
            frequencyLabel.Location = new Point(10, dateTextBox.Bottom + 10);
            frequencyLabel.AutoSize = true;

            TextBox frequencyTextBox = new TextBox();
            frequencyTextBox.Location = new Point(10, frequencyLabel.Bottom + 10);
            frequencyTextBox.Width = inputForm.Width - 40;

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(10, frequencyTextBox.Bottom +10);
            okButton.AutoSize = true;


            inputForm.Controls.Add(promptLabel);
            inputForm.Controls.Add(taskTextBox);
            inputForm.Controls.Add(personLabel);
            inputForm.Controls.Add(personTextBox);
            inputForm.Controls.Add(dateLabel);
            inputForm.Controls.Add(dateTextBox);
            inputForm.Controls.Add(frequencyLabel);
            inputForm.Controls.Add(frequencyTextBox);
            inputForm.Controls.Add(okButton);

            inputForm.AcceptButton = okButton;

            inputForm.ShowDialog();

            string task = taskTextBox.Text;
            string person = personTextBox.Text;
            string date = dateTextBox.Text;
            string frequency = frequencyTextBox.Text;

            return $"Task: {task}\nPerson: {person}\nDate: {date}\nFrequency: {frequency}";
        }



    }
}
