<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gridview_gridArtister.ascx.cs" Inherits="UserControls_Gridview_gridArtister" %>



<!-- GridView som visar hel tabell inkl paging etc: -->
                              
 
 <asp:GridView ID="gridArtister" runat="server" DataSourceID="main" 
   AllowPaging="True" OnRowCommand="gridArtister_RowCommand"  HeaderStyle-CssClass="header"
   AllowSorting="True" PageSize="6" >
                                          
                                   
   <Columns>
                                          
     <asp:TemplateField HeaderText="Artist" ItemStyle-CssClass="grid_style"
     SortExpression="Artist" HeaderStyle-CssClass="pos_gridartist">
                                    
       <ItemTemplate>
          <asp:Button ID="Artist" runat="server" CssClass="arti" Text='<%#Eval("Artist") %>'
          CommandArgument='<%#Eval("Artist_no") %>' CommandName="Artist" />
       </ItemTemplate>        
       <ItemStyle CssClass="grid_style" />
    </asp:TemplateField>
                                       
                                       
                                       
                                       
   <asp:BoundField DataField="Album" HeaderText="Titel" 
   ItemStyle-CssClass="grid_style"  HeaderStyle-CssClass="pos_gridartist" 
   SortExpression="Album">
      <ItemStyle CssClass="grid_style" />
  </asp:BoundField>
  <asp:BoundField DataField="Format" HeaderText="Format"  
  ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_gridartist" 
   SortExpression="Format">
      <ItemStyle CssClass="grid_style" />
  </asp:BoundField>
   <asp:BoundField DataField="Press" HeaderText="Press" 
   ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_gridartist" 
   SortExpression="Press">
       <ItemStyle CssClass="grid_style" />
   </asp:BoundField>
   <asp:BoundField DataField="Ar" HeaderText="År" HeaderStyle-CssClass="pos_gridartist" 
   ItemStyle-CssClass="grid_style" SortExpression="Ar">
       <ItemStyle CssClass="grid_style" />
   </asp:BoundField>
                                          
   <asp:TemplateField HeaderText="Komtr" HeaderStyle-CssClass="cmt_align"
   ItemStyle-CssClass="grid_style">
      <ItemTemplate>
           <asp:Button ID="kommentar" runat="server" CssClass="cmt" Text='<%#Eval("#") %>'
           CommandArgument='<%#Eval("#") %>' CommandName="Kommentar" />
      </ItemTemplate>        
      <HeaderStyle CssClass="cmt_align" />
      <ItemStyle CssClass="grid_style" />
   </asp:TemplateField>
                                  
  
  
  </Columns>
                                        
                             
                             
</asp:GridView>
                             
                               
<!-- Obj-datasrc för gridview gridArtister: -->
                                    
<asp:ObjectDataSource ID="main" runat="server"
     TypeName="DB_proc.Proc_act"  SelectMethod="GetWholeDB"
     EnableCaching="false" CacheDuration="3600" 
     OnSelected="ObjectDataSourceMain_Selected">
</asp:ObjectDataSource>
               