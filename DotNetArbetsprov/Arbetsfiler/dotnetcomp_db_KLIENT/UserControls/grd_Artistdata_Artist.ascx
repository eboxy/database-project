﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="grd_Artistdata_Artist.ascx.cs" Inherits="UserControls_grd_Artistdata_Artist" %>


 <!-- GridView som visar data om en artist: -->


<asp:GridView ID="grd_Artistdata_Artist" runat="server"  AllowPaging="false"
 OnRowCommand="grd_Artistdata_Artist_RowCommand" HeaderStyle-CssClass="header">
                                    
              
   <Columns>
                            
                            
    <asp:BoundField DataField="Artist" HeaderText="Artist" ItemStyle-CssClass="grid_style" 
    HeaderStyle-CssClass="pos_gridartistdata" />
                               
    <asp:BoundField DataField="VPfr" HeaderText="VPfr" ItemStyle-CssClass="grid_style" 
    HeaderStyle-CssClass="pos_gridartistdata" />
                             
    <asp:BoundField DataField="Vptill" HeaderText="Vptill" ItemStyle-CssClass="grid_style" 
     HeaderStyle-CssClass="pos_gridartistdata" />
                             
    <asp:BoundField DataField="Ursland" HeaderText="Ursland" ItemStyle-CssClass="grid_style" 
    HeaderStyle-CssClass="pos_gridartistdata" />
                             
    <asp:BoundField DataField="Ursstad" HeaderText="Ursstad" ItemStyle-CssClass="grid_style" 
    HeaderStyle-CssClass="pos_gridartistdata" />
                             
    <asp:BoundField DataField="Musiktyp" HeaderText="Musiktyp" ItemStyle-CssClass="grid_style" 
    HeaderStyle-CssClass="pos_gridartistdata" />
                             
                             
    <asp:TemplateField HeaderText="Kort biografi" ItemStyle-CssClass="grid_style" 
    HeaderStyle-CssClass="pos_kortbio" >
      <ItemTemplate>
          <asp:Button ID="Artist_data" runat="server" CssClass="arti" Text='<%#Eval("Artist") %>'
          CommandArgument='<%#Eval("Artist") %>' CommandName="Artist_kortbio" />
      </ItemTemplate>        
   </asp:TemplateField>
                             
                     
                     
  </Columns>
               
               
</asp:GridView>