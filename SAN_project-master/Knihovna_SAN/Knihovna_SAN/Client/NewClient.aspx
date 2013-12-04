<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewClient.aspx.cs" Inherits="Knihovna_SAN.Client.NewClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Registrace noveho klienta</h1><hr>

    <table>

        <tr>
            <td>Jmeno</td>
            <td><asp:TextBox ID="TxtBoxName" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Tuto polozku musite vyplnit." 
                    ControlToValidate="TxtBoxName"></asp:RequiredFieldValidator></td>
            
        </tr>

         <tr>
            <td>Prijmeni</td>
            <td><asp:TextBox ID="TxtBoxSurname" runat="server" ></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Tuto polozku musite vyplnit." 
                    ControlToValidate="TxtBoxSurname"></asp:RequiredFieldValidator></td>
        </tr>

         <tr>
            <td>Email</td>
            <td><asp:TextBox ID="TxtBoxEmail" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Tuto polozku musite vyplnit."  
                    ControlToValidate="TxtBoxEmail"></asp:RequiredFieldValidator></td>
        </tr>

         <tr>
            <td>Telefon</td>
            <td><asp:TextBox ID="TxtBoxPhone" runat="server"></asp:TextBox></td>
            
        </tr>

         <tr>
            <td>Datum narozeni</td>
            <td><asp:TextBox ID="TxtBoxBirthDate" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Tuto polozku musite vyplnit ve tvaru DD/MM/YYYY." 
                     ControlToValidate="TxtBoxBirthDate"></asp:RequiredFieldValidator></td>
        </tr>

         <tr>
            <td>Ulice</td>
            <td><asp:TextBox ID="TxtBoxStreet" runat="server"></asp:TextBox></td>
            
        </tr>

         <tr>
            <td>Mesto</td>
            <td><asp:TextBox ID="TxtBoxCity" runat="server"></asp:TextBox></td>
            
        </tr>

         <tr>
            <td>PSC</td>
            <td><asp:TextBox ID="TxtBoxZIP" runat="server"></asp:TextBox></td>
            
        </tr>

        <tr>
            <td>Stat</td>
            <td><asp:TextBox ID="TxtBoxCountry" runat="server"></asp:TextBox>
              
            </td>
            
        </tr>

      

        <tr>
            <td>Login</td>
            <td><asp:TextBox ID="TxtBoxLogin" runat="server" ></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Tuto polozku musite vyplnit." 
                    ControlToValidate="TxtBoxLogin"></asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td>Heslo</td>
            <td><asp:TextBox ID="TxtBoxPass" runat="server" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Tuto polozku musite vyplnit." 
                    ControlToValidate="TxtBoxPass"></asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td>Heslo znovu</td>
            <td><asp:TextBox ID="TxtBoxPassAgain" runat="server" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ErrorMessage="Tuto polozku musite vyplnit." 
                    ControlToValidate="TxtBoxPassAgain"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TxtBoxPassAgain" ControlToValidate="TxtBoxPass" 
                    Display="Dynamic" ErrorMessage="Hesla musi byt stejna."></asp:CompareValidator>
            </td>
        </tr>




    </table>

      <asp:Button ID="BtnInsertClient" runat="server" Text="Vlozit noveho klienta" onclick="BtnInsertClient_Click" 
         />




</asp:Content>
