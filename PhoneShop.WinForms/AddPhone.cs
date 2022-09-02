using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Text;
using System.Windows.Forms;

namespace Phoneshop.WinForms
{
    public partial class AddPhone : Form
    {
        private readonly IPhoneService _phoneService;
        private readonly ILoggerService _loggerService;

        public AddPhone(IPhoneService phoneService, ILoggerService loggerService)
        {
            InitializeComponent();
            _phoneService = phoneService;
            _loggerService = loggerService;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!CheckPhone()) return;
            _phoneService.Create(new Phone
            {
                Brand = new Brand
                {
                    Name = Brand_Label.Text
                },
                Type = Type_Label.Text,
                Description = Description_Label.Text,
                Price = Convert.ToDouble(Price_Label.Text),
                Stock = Convert.ToInt32(Stock_label.Text)
            });

            DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool CheckPhone()
        {
            var messages = new StringBuilder();

            if (string.IsNullOrEmpty(Brand_Label.Text))
                messages.AppendLine("Brand is required");
            if (string.IsNullOrEmpty(Type_Label.Text))
                messages.AppendLine("Type is required");
            if (string.IsNullOrEmpty(Description_Label.Text))
                messages.AppendLine("Description is required");
            if (string.IsNullOrEmpty(Price_Label.Text) || Convert.ToInt32(Price_Label.Text) <= 0)
                messages.AppendLine("Price is invalid. It can't be negative.");
            if (string.IsNullOrEmpty(Stock_label.Text) || Convert.ToInt32(Stock_label.Text) <= 0)
                messages.AppendLine("Stock is invalid. It can't be negative.");

            if (messages.Length <= 0) return true;
            MessageBox.Show(messages.ToString(), "Errors", MessageBoxButtons.OK);
            return false;
        }
    }
}