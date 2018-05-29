<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookABanker.aspx.cs" Inherits="BankForms.Bank.BookABanker" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    <h2>Book A Banker</h2>

  <br />
     <asp:Label runat="server" ID="errorOutput" CssClass="danger error"></asp:Label>
   <br />

    <div class="form-vertical">

        <h4>Basic personal information</h4>
        <hr />

        <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="titleInput" CssClass="col-4 col-form-label control-label">Title</asp:Label>
            <div class="col-8">
                <asp:DropDownList runat="server" ID="titleInput" CssClass="form-control" DataValueField="value" DataTextField="text"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="titleInput"
                    CssClass="text-danger" ErrorMessage="Please choose an option" />
            </div>
        </div>

        <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="firstNameInput" CssClass="col-4 col-form-label control-label">First name</asp:Label>
            <div class="col-8">
                <asp:TextBox runat="server" ID="firstNameInput" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="firstNameInput"
                    CssClass="text-danger" ErrorMessage="Please ensure that only alpha characters and hyphen are entered. This field must begin with an alpha character." />
            </div>
        </div>

        <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="firstNameInput" CssClass="col-4 col-form-label control-label">Surname</asp:Label>
            <div class="col-8">
                <asp:TextBox runat="server" ID="surnameInput" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="firstNameInput"
                    CssClass="text-danger" ErrorMessage="Please ensure that only alpha characters and hyphen are entered. This field must begin with an alpha character." />
            </div>
        </div>

        <h4>Primary contact details</h4>
        <hr />


        <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="contactNoInput" CssClass="col-4 col-form-label control-label">Contact no</asp:Label>
            <div class="col-8">
                <asp:TextBox runat="server" ID="contactNoInput" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="contactNoInput"
                    CssClass="text-danger" ErrorMessage="Please ensure the number and format are correct, e.g. 083 123 3469 for a local number or +41441234567 for an international number" />
            </div>
        </div>

        <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="emailAddressInput" CssClass="col-4 col-form-label control-label">Email address</asp:Label>
            <div class="col-8">
                <asp:TextBox runat="server" ID="emailAddressInput" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="emailAddressInput"
                    CssClass="text-danger" ErrorMessage="Please enter correct email address" />
            </div>
        </div>



        <h4>Tell us a bit more</h4>
        <hr />

        <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="companyInput" CssClass="col-4 col-form-label control-label">Company</asp:Label>
            <div class="col-8">
                <asp:TextBox runat="server" ID="companyInput" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="companyInput"
                    CssClass="text-danger" ErrorMessage="Please enter your company name" />
            </div>
        </div>
        <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="existingClientInput" CssClass="col-4 col-form-label control-label">Are you an existing Nedbank client?</asp:Label>
            <div class="col-8">
                <asp:CheckBox runat="server" ID="existingClientInput" CssClass="form-control"></asp:CheckBox>
            </div>
        </div>

       

            <div class="form-group  row">
                <asp:Label runat="server" AssociatedControlID="queryInput" CssClass="col-4 col-form-label control-label">What would you like assistance with?</asp:Label>
                <div class="col-8">
                    <asp:TextBox runat="server" ID="queryInput" CssClass="form-control"></asp:TextBox>
                </div>
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="queryInput"
                    CssClass="text-danger" ErrorMessage="Please tell us what you need assistance with" />
            
            </div>

            <div class="form-group  row">
                <asp:Label runat="server" AssociatedControlID="comsInput" CssClass="col-4 col-form-label control-label">Preferred method of communication</asp:Label>
                <div class="col-8">
                    <asp:CheckBoxList ID="comsInput"
                        AutoPostBack="False"
                        DataTextField="text"
                        DataValueField="value"
                        runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>

          <div class="form-group  row">
            <asp:Label runat="server" AssociatedControlID="regionInput" CssClass="col-4 col-form-label control-label">Region</asp:Label>
            <div class="col-8">
                <asp:DropDownList runat="server" ID="regionInput" CssClass="form-control" DataValueField="value" DataTextField="text"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="regionInput"
                    CssClass="text-danger" ErrorMessage="Please choose an option" />
            </div>
        </div>

            <div class="form-group row">
                <asp:Label runat="server" AssociatedControlID="provisionalTimeInput" CssClass="col-4 col-form-label control-label">Preferred time to meet?</asp:Label>
                <div class="col-8">
                   
                    <asp:RadioButtonList ID="provisionalTimeInput"
                        AutoPostBack="False"
                        DataTextField="text"
                        DataValueField="value"
                        runat="server">
                    </asp:RadioButtonList>
                 
                </div>
            </div>
        <hr />
            <div class="form-group row">
                <asp:Label runat="server" AssociatedControlID="provisionalDateInput" CssClass="col-4 col-form-label control-label">Preferred day to meet?</asp:Label>
                <div class="col-8">

                    <asp:Calendar  runat="server" ID="provisionalDateInput" CssClass="form-control"></asp:Calendar>

                     </div>

            </div>

        <br />
            <div class="form-group row">
                <div>
                    <asp:Button runat="server" OnClick="bookBanker_Click" Text="I'm done" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
  
</asp:Content>

