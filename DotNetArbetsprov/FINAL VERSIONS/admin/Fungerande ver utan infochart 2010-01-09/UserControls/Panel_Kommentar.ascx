<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Panel_Kommentar.ascx.cs" Inherits="UserControls_Panel_Kommentar" %>

    
    <!-- Administrering av längre kommentarer: -->

    <asp:Panel ID="pnlKommentar" runat="server" Visible="false">
                    
        <asp:TextBox ID="txtKommentar" TextMode="MultiLine" MaxLength="6000" 
           runat="server" CssClass="txtKortbio">
        </asp:TextBox>
                             
       <asp:Button ID="dynbtnKommentar" runat="server" CssClass="cmt dynbtnKortbio" 
        Text="Till" OnClick="dynbtnKommentar_OnClick" />
                             
        <asp:Button ID="dynbtnFetchKommentar" runat="server" CssClass="cmt dynbtnFetchKbio" 
        Text="Från" OnClick="dynbtnFetchKommentar_OnClick" />
                       
        <asp:Button ID="dynbtnRensaSkarm_Kom" runat="server" CssClass="cmt dynbtnRensaSkarm" 
        Text="Rensa" OnClick="dynbtnRensaSkarm_Kom_OnClick" />
                             
        <asp:Label ID="lblKommentarNo" runat="server" CssClass="label1 lblArtistNo" 
        Text="Kommentarno"></asp:Label>
                             
        <asp:TextBox ID="txtKommentarNo" CssClass="txtArtistNo" runat="server" Size="1">
        </asp:TextBox>        
                         
    </asp:Panel>             