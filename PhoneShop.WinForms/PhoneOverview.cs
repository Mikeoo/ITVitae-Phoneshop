using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Phoneshop.WinForms
{
    public partial class PhoneOverview : Form
    {
        private List<Phone> _phones = new();
        private readonly IPhoneService _phoneService;
        private readonly ILoggerService _loggerService;

        public PhoneOverview(IPhoneService phoneService, ILoggerService loggerService)
        {
            _phoneService = phoneService;
            _loggerService = loggerService;

            InitializeComponent();

            GetPhones();
        }

        private void PhoneOverviewStart(object sender, EventArgs e)
        {
            CreatePhoneList();
        }

        private void LstPhones_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (Phone)Phones_Listbox.SelectedItem;
            Brand_Label.Text = selected.Brand.Name;
            Description_Box_Label.Text = selected.Description;
            Price_Label.Text = selected.Price.ToString(CultureInfo.InvariantCulture);
            Type_Label.Text = selected.Type;
            Stock_Label.Text = selected.Stock.ToString();

            Remove_Phone_Button.Enabled = true;
        }

        private void Search_Textbox_TextChanged(object sender, EventArgs e)
        {
            GetPhones(Search_Textbox.Text);
            CreatePhoneList();
        }

        private void CreatePhoneList()
        {
            Phones_Listbox.DataSource = _phones;
            Phones_Listbox.DisplayMember = nameof(Phone.FullName);
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddPhone_Button_Click(object sender, EventArgs e)
        {
            var addPhoneForm = new AddPhone(_phoneService, _loggerService);
            addPhoneForm.ShowDialog();

            if (addPhoneForm.DialogResult == DialogResult.OK)
            {
                GetPhones(string.Empty);
                CreatePhoneList();
            }
        }

        private void Remove_Phone_Button_Click(object sender, EventArgs e)
        {
            var selected = (Phone)Phones_Listbox.SelectedItem;
            _phoneService.Delete(selected.Id);
            GetPhones(string.Empty);
            var amountPhones = Phones_Listbox.Items.Count;

            if (amountPhones < 2)
            {
                Brand_Label.Text = string.Empty;
                Description_Box_Label.Text = string.Empty;
                Price_Label.Text = string.Empty;
                Type_Label.Text = string.Empty;
                Stock_Label.Text = string.Empty;
                Remove_Phone_Button.Enabled = false;
            }
            CreatePhoneList();
        }

        private void GetPhones(string search = "")
        {
            if (string.IsNullOrEmpty(search))
                _phones = _phoneService.GetAll().ToList();
            else if (search.Length <= 3)
                // ReSharper disable once RedundantJumpStatement
                return;
            else
                _phones = _phoneService.Search(search).ToList();
        }
    }
}