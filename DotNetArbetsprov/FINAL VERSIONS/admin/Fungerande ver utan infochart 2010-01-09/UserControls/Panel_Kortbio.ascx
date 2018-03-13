<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Panel_Kortbio.ascx.cs" Inherits="UserControls_Panel_Kortbio" %>

   
   <!-- Kortbio-multiline-textruta och knapp för inmatning till DB: -->

     
     <asp:Panel ID="pnlKortbio" runat="server" Visible="false">
                    
          <asp:TextBox ID="txtKortbio" TextMode="MultiLine" MaxLength="6000" 
            runat="server" CssClass="txtKortbio">
          </asp:TextBox>
                         
          <asp:Button ID="dynbtnKortbio" runat="server" CssClass="cmt dynbtnKortbio" 
           Text="Till" OnClick="dynbtnKortbio_OnClick" />
                         
          <asp:Button ID="dynbtnFetchKbio" runat="server" CssClass="cmt dynbtnFetchKbio" 
          Text="Från" OnClick="dynbtnKortbioFetch_OnClick" />
                   
           <asp:Button ID="dynbtnRensaSkarm" runat="server" CssClass="cmt dynbtnRensaSkarm" 
           Text="Rensa" OnClick="dynbtnRensaSkarmArtist_OnClick" />
                         
           <asp:Label ID="lblArtistNo" runat="server" CssClass="label1 lblArtistNo" 
           Text="Artno"></asp:Label>
                         
           <asp:TextBox ID="txtArtistNo" CssClass="txtArtistNo" runat="server" Size="1">
           </asp:TextBox>        
                         
      </asp:Panel>             