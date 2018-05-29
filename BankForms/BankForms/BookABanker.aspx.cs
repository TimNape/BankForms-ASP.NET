using BankFormsDal.dto;
using BankFormsDal.interfaces;
using BankFormsDomain;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BankForms.Bank
{

    public partial class BookABanker : System.Web.UI.Page
    {
        // This properties are set by PropertyInjectionModule.
        public IBankerBookingDal _bankerBookingDal { get; set; }
        public ILeadDal _leadDal { get; set; }

        List<OptionDto> titles = new List<OptionDto>();
        List<OptionDto> timeSlots = new List<OptionDto>();
        List<OptionDto> comsMethods = new List<OptionDto>();
        List<OptionDto> bankingRegions = new List<OptionDto>();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                initializeForm(sender, e);
            }
        }


        protected void bookBanker_Click(object sender, EventArgs e)
        {

            submitForm(sender, e);
        }

        private void submitForm(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(typeof(_Default));

            BankerBooking bankerBooking = new BankerBooking(_bankerBookingDal);


            try
            {
                loadBankerBookingForm(bankerBooking, sender, e);
            }
            catch (Exception ex)
            {
                logger.Error("Failed to load banker booking form", ex);
                displayUIError("Failed to load booking form");

            }

            try
            {
                bankerBooking.save();

                Response.Redirect("SuccessfulSubmit.aspx");

            }
            catch (Exception ex)
            {
                logger.Error("Failed to save banker booking form", ex);

                displayUIError("Failed to save banker booking form");

            }

        }

        private void displayUIError(string errorMsg)
        {
            errorOutput.Text = errorMsg;
        }



        #region initialize form

        /// <summary>
        /// Initialise form values i.e. dropdowns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initializeForm(object sender, EventArgs e)
        {
            //initialize drop downs
            initializeFormTitles(sender, e);
            initializeFormComsMethods(sender, e);
            initializeFormBankingRegions(sender, e);
            initializeFormTimeSlots(sender, e);
        }



        /// <summary>
        /// initialize communication methods drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initializeFormComsMethods(object sender, EventArgs e)
        {
            var options = _leadDal.getComsMethods();
            foreach (var option in options)
            {
                comsMethods.Add(new OptionDto() { value = option.id, text = option.caption });
            }
            comsInput.DataSource = comsMethods;
            comsInput.DataBind();
        }

        /// <summary>
        /// initialize timeslopts drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initializeFormTimeSlots(object sender, EventArgs e)
        {
            //initialize banking region drop town
            var options = _bankerBookingDal.getBankerTimeSlots();
            foreach (var option in options)
            {
                timeSlots.Add(new OptionDto() { value = option.id, text = option.caption });
            }
            provisionalTimeInput.DataSource = timeSlots;
            provisionalTimeInput.DataBind();
        }

        /// <summary>
        /// initialize titles drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initializeFormTitles(object sender, EventArgs e)
        {
            //initialize banking region drop town
            var options = _leadDal.getTitles();
            foreach (var option in options)
            {
                titles.Add(new OptionDto() { value = option.id, text = option.caption });
            }
            titleInput.DataSource = titles;
            titleInput.DataBind();
        }

        /// <summary>
        /// initialize banking region drop down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initializeFormBankingRegions(object sender, EventArgs e)
        {
            //initialize banking region drop town
            List<BankingRegionDto> bankingRegions = _bankerBookingDal.getBankingRegions();
            foreach (var option in bankingRegions)
            {
                this.bankingRegions.Add(new OptionDto() { value = option.id, text = option.caption });
            }
            regionInput.DataSource = this.bankingRegions;
            regionInput.DataBind();
        }
        #endregion

        private void loadBankerBookingForm(BankerBooking bankerBooking, object sender, EventArgs e)
        {

            bankerBooking.setTitle(Convert.ToInt32(titleInput.SelectedValue));
            bankerBooking.setFirstName(firstNameInput.Text);
            bankerBooking.setSurname(surnameInput.Text);

            bankerBooking.setContactNo(contactNoInput.Text);
            bankerBooking.setEmailAddress(emailAddressInput.Text);

            bankerBooking.setCompany(companyInput.Text);

            bankerBooking.setExistingClient(existingClientInput.Checked);
            bankerBooking.setBankingRegion(Convert.ToInt32(regionInput.SelectedValue));
            bankerBooking.setProvisionalDate(provisionalDateInput.SelectedDate);
            bankerBooking.setProvisionalTime(Convert.ToInt32(provisionalTimeInput.SelectedValue));
            bankerBooking.setQuery(queryInput.Text);

            List<LeadComsMethodDto> comsMethods = new List<LeadComsMethodDto>();


            foreach (ListItem selected in comsInput.Items)
            {

                if (selected.Selected)
                {
                    var comsMethod = new LeadComsMethodDto()
                    {
                        comsMethodId = Convert.ToInt32(selected.Value)
                    };
                    comsMethods.Add(comsMethod);
                }

            }

            bankerBooking.add(comsMethods);

        }

        
    }
}