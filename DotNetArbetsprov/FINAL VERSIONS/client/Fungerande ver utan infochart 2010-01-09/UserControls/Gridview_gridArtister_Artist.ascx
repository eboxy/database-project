<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gridview_gridArtister_Artist.ascx.cs" Inherits="UserControls_Gridview_gridArtister_Artist" %>



<!-- GridView som visar hel tabell inkl paging etc: -->
                              
 
 <asp:GridView ID="gridArtister_Artist" runat="server" DataSourceID="main_Artist" 
   AllowPaging="True"  HeaderStyle-CssClass="header"
   AllowSorting="True" PageSize="8" OnRowCommand="gridArtister_Artist_RowCommand"   >
                               
  <RowStyle Height="35px" />           
                                   
  <Columns>
                                          
    <asp:TemplateField HeaderText="Artist" ItemStyle-CssClass="grid_style"
    SortExpression="Artist" HeaderStyle-CssClass="pos_gridartist">
                                    
         <ItemTemplate>
              <asp:Button ID="Artist" runat="server" CssClass="arti" Text='<%#Eval("Artist") %>'
               CommandArgument='<%#Eval("Artist") %>' CommandName="Artist_kortbio" />
         </ItemTemplate>        
         <ItemStyle CssClass="grid_style" />
   </asp:TemplateField>
                                       
                                       
                                       
                                       
   <asp:BoundField DataField="VPfr" HeaderText="VPfr " 
    ItemStyle-CssClass="grid_style"  HeaderStyle-CssClass="pos_gridartist" 
    SortExpression="VPfr">
       <ItemStyle CssClass="grid_style" />
   </asp:BoundField>
   <asp:BoundField DataField="VPtill" HeaderText="VPtill"  
   ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_gridartist" 
   SortExpression="VPtill">
      <ItemStyle CssClass="grid_style" />
   </asp:BoundField>
   <asp:BoundField DataField="Ursland" HeaderText="Ursland" 
   ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_gridartist" 
   SortExpression="Ursland">
     <ItemStyle CssClass="grid_style" />
   </asp:BoundField>
   <asp:BoundField DataField="Ursstad" HeaderText="Ursstad" HeaderStyle-CssClass="pos_gridartist" 
   ItemStyle-CssClass="grid_style" SortExpression="Ursstad">
     <ItemStyle CssClass="grid_style" />
   </asp:BoundField>
   <asp:BoundField DataField="Musiktyp" HeaderText="Musiktyp" HeaderStyle-CssClass="pos_gridartist" 
   ItemStyle-CssClass="grid_style" SortExpression="Musiktyp">
      <ItemStyle CssClass="grid_style" />
  </asp:BoundField>
                                       
                                          
                                       
                                  
   </Columns>
                                        
                             
                             
</asp:GridView>
                             
                             
                             
<!-- Obj-datasrc för gridview gridArtister: -->
                                    
<asp:ObjectDataSource ID="main_Artist" runat="server"
     TypeName="DB_proc_Artist.Artist"  SelectMethod="GetWholeDB"
     EnableCaching="true" CacheDuration="3600" 
     OnSelected="ObjectDataSourceMain_Selected">
</asp:ObjectDataSource>
               