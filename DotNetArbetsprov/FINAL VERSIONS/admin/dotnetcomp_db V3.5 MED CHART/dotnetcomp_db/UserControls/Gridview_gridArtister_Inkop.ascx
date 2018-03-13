<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gridview_gridArtister_Inkop.ascx.cs" Inherits="UserControls_Gridview_gridArtister_Inkop" %>



<!-- GridView som visar hel tabell inkl paging etc: -->
                              
 <asp:GridView ID="gridArtister_Inkop" runat="server" DataSourceID="main_Inkop" 
  AllowPaging="True" OnRowCommand="gridArtister_Inkop_RowCommand"  HeaderStyle-CssClass="header"
  AllowSorting="True" PageSize="6" >
                                          
                                   
   <Columns>
                                          
               
     <asp:TemplateField HeaderText="Mark" ItemStyle-CssClass="grid_style" 
     HeaderStyle-CssClass="pos_gridartist">
           <HeaderTemplate>
                                        
              <TF:DerivCheckBox ID="chkInkval_ALL" runat="server" Checked='<%# Bind("ValInk")%>' AutoPostBack="true"
              UnText='<%#Eval("Skiv_no") %>' OnCheckedChanged="chkInkvalALLMain_CheckedChanged" />
                                        
          </HeaderTemplate>
                                        
          <ItemTemplate> 

              <TF:DerivCheckBox ID="chkInkval" runat="server" Checked='<%# Bind("ValInk")%>' AutoPostBack="true"
              UnText='<%#Eval("Skiv_no") %>' OnCheckedChanged="chkInkval_CheckedChanged" />
                                         
           </ItemTemplate>
                                          
     </asp:TemplateField>
                                          
                                       
                                       
   <asp:TemplateField HeaderText="Artist" ItemStyle-CssClass="grid_style"
    SortExpression="Artist" HeaderStyle-CssClass="pos_gridartist">
       <ItemTemplate>
          <asp:Button ID="Artist" runat="server" CssClass="arti" Text='<%#Eval("Artist") %>'
           CommandArgument='<%#Eval("Art_no") %>' CommandName="Artist" />
       </ItemTemplate>        
       <ItemStyle CssClass="grid_style" />
   </asp:TemplateField>
                                       
                                       
                                       
                                       
  <asp:BoundField DataField="Titel" HeaderText="Titel" 
  ItemStyle-CssClass="grid_style"  HeaderStyle-CssClass="pos_gridartist" 
  SortExpression="Titel">
      <ItemStyle CssClass="grid_style" />
 </asp:BoundField>
 <asp:BoundField DataField="Form" HeaderText="Format"  
 ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_gridartist" 
 SortExpression="Form">
    <ItemStyle CssClass="grid_style" />
</asp:BoundField>
 <asp:BoundField DataField="Land" HeaderText="Press" 
 ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_gridartist" 
 SortExpression="Land">
      <ItemStyle CssClass="grid_style" />
  </asp:BoundField>
  <asp:BoundField DataField="Utg" HeaderText="År" HeaderStyle-CssClass="pos_gridartist" 
  ItemStyle-CssClass="grid_style" SortExpression="Utg">
     <ItemStyle CssClass="grid_style" />
  </asp:BoundField>
                                          
   <asp:TemplateField HeaderText="Komtr" HeaderStyle-CssClass="cmt_align"
    ItemStyle-CssClass="grid_style">
       <ItemTemplate>
          <asp:Button ID="kommentar" runat="server" CssClass="cmt" Text='<%#Eval("Skiv_no") %>'
           CommandArgument='<%#Eval("Skiv_no") %>' CommandName="Kommentar" />
        </ItemTemplate>        
        <HeaderStyle CssClass="cmt_align" />
       <ItemStyle CssClass="grid_style" />
  </asp:TemplateField>
                                  
                               
  <asp:BoundField DataField="Inm_dat" HeaderText="InmDat" DataFormatString="{0:yyyy-MM-dd}" 
   HtmlEncode="false" HeaderStyle-CssClass="pos_gridartist" ItemStyle-CssClass="grid_style" 
   SortExpression="Inm_dat">
      <ItemStyle CssClass="grid_style" />
 </asp:BoundField>
 <asp:BoundField DataField="Kop_grad" HeaderText="Kgrad" HeaderStyle-CssClass="pos_gridartist" 
 ItemStyle-CssClass="grid_style" SortExpression="Kop_grad">
     <ItemStyle CssClass="grid_style" />
 </asp:BoundField>
 <asp:BoundField DataField="Kop_kat" HeaderText="Kkat" HeaderStyle-CssClass="pos_gridartist" 
 ItemStyle-CssClass="grid_style" SortExpression="Kop_kat">
    <ItemStyle CssClass="grid_style" />
 </asp:BoundField>
 <asp:BoundField DataField="Ca_pris" HeaderText="Capris" HeaderStyle-CssClass="pos_gridartist" 
 ItemStyle-CssClass="grid_style" SortExpression="Ca_pris">
    <ItemStyle CssClass="grid_style" />
 </asp:BoundField>
                                       
                                       
     </Columns>
                                        
</asp:GridView>
                             
                              
                              

<!-- Obj-datasrc för gridview gridArtister: -->
                                    
 <asp:ObjectDataSource ID="main_Inkop" runat="server"
      TypeName="DB_proc_Inkop.Inkop"  SelectMethod="GetWholeDB"
      EnableCaching="false" CacheDuration="3600" 
      OnSelected="ObjectDataSourceMain_Selected">
 </asp:ObjectDataSource>
               
