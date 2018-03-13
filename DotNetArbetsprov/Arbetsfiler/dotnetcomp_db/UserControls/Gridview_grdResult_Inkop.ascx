<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gridview_grdResult_Inkop.ascx.cs" Inherits="UserControls_Gridview_grdResult_Inkop" %>




<!-- GridView som visar hel tabell inkl paging etc: -->
                              
<asp:GridView ID="grdResult_Inkop" runat="server" BackColor="White"
   AllowPaging="true" OnRowCommand="gridArtister_Inkop_RowCommand"  HeaderStyle-CssClass="header"
   AllowSorting="false" PageSize="6"  OnPageIndexChanging="grdResult_Inkop_PageIndexChanging" 
   AutoGenerateColumns="false">
                                
                               
                               
   <Columns>
                                          
                                    
                                    
    <asp:TemplateField HeaderText="Mark" ItemStyle-CssClass="grid_style" 
     HeaderStyle-CssClass="pos_gridartist">
        <HeaderTemplate>
                                        
           <TF:DerivCheckBox ID="chkInkval_ALL" runat="server" Checked='<%# Bind("ValInk")%>' AutoPostBack="true"
           UnText='<%#Eval("Skiv_no") %>' OnCheckedChanged="chkInkvalALLGrdRes_CheckedChanged"  
                                               EnableViewState="true" />
                                        
       </HeaderTemplate>
                                        
       <ItemTemplate> 

         <TF:DerivCheckBox ID="chkInkval" runat="server" Checked='<%# Bind("ValInk")%>' AutoPostBack="true"
          UnText='<%#Eval("Skiv_no") %>' OnCheckedChanged="chkInkval_CheckedChanged" EnableViewState="true" />
                                         
       </ItemTemplate>
                                          
    </asp:TemplateField>
                                          
                                       
                                       
   <asp:TemplateField ItemStyle-CssClass="grid_style"
   SortExpression="Artist" HeaderStyle-CssClass="pos_grdresult">
                                          
       <HeaderTemplate>
          <asp:LinkButton ID="lnkbtnArtist" runat="server" CommandName="Sort" 
          ForeColor="#F7F7F7" CommandArgument="Artist" OnCommand="SortInkop_Command">
          Artist</asp:LinkButton>
       </HeaderTemplate>
       <ItemTemplate>
          <asp:Button ID="Artist" runat="server" CssClass="arti" Text='<%#Eval("Artist") %>'
          CommandArgument='<%#Eval("Art_no") %>' CommandName="Artist" 
          OnCommand="SortInkop_Command" />
       </ItemTemplate>        
       <ItemStyle CssClass="grid_style" />
   </asp:TemplateField>
                                       
                                       
   <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
      <HeaderTemplate>
         <asp:LinkButton ID="lnkbtnAlbum" runat="server" CommandName="Sort" 
         ForeColor="#F7F7F7" CommandArgument="Titel" OnCommand="SortInkop_Command">
         Titel</asp:LinkButton>
      </HeaderTemplate>
      <ItemTemplate>
         <asp:Label ID="lblSortAlbum" runat="server" Text='<%# Eval("Titel") %>'
         EnableTheming="false">
         </asp:Label>                                      
      </ItemTemplate>
      <ItemStyle CssClass="grid_style" />             
  </asp:TemplateField> 
                                       
                                       
  <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
     <HeaderTemplate>
       <asp:LinkButton ID="lnkbtnForm" runat="server" CommandName="Sort" 
       ForeColor="#F7F7F7" CommandArgument="Form" OnCommand="SortInkop_Command">
       Format</asp:LinkButton>
     </HeaderTemplate>
     <ItemTemplate>
       <asp:Label ID="lblSortForm" runat="server" Text='<%# Eval("Form") %>'
       EnableTheming="false">
       </asp:Label>                                      
    </ItemTemplate>
    <ItemStyle CssClass="grid_style" />             
 </asp:TemplateField> 
                                     
                                     
                                     
  <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
     <HeaderTemplate>
        <asp:LinkButton ID="lnkbtnLand" runat="server" CommandName="Sort" 
        ForeColor="#F7F7F7" CommandArgument="Land" OnCommand="SortInkop_Command">
        Press</asp:LinkButton>
     </HeaderTemplate>
     <ItemTemplate>
        <asp:Label ID="lblSortLand" runat="server" Text='<%# Eval("Land") %>'
        EnableTheming="false">
        </asp:Label>                                      
     </ItemTemplate>
     <ItemStyle CssClass="grid_style" />             
  </asp:TemplateField> 
                                       
                                       
                                       
                                       
  <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
    <HeaderTemplate>
      <asp:LinkButton ID="lnkbtnUtg" runat="server" CommandName="Sort" 
      ForeColor="#F7F7F7" CommandArgument="Utg" OnCommand="SortInkop_Command">
      År</asp:LinkButton>
   </HeaderTemplate>
   <ItemTemplate>
       <asp:Label ID="lblSortUtg" runat="server" Text='<%# Eval("Utg") %>'
       EnableTheming="false">
       </asp:Label>                                      
    </ItemTemplate>
    <ItemStyle CssClass="grid_style" />             
 </asp:TemplateField> 
                                       
                                       
                                  
   <asp:TemplateField HeaderText="Komtr" HeaderStyle-CssClass="cmt_align"
    ItemStyle-CssClass="grid_style">
      <ItemTemplate>
         <asp:Button ID="kommentar" runat="server" CssClass="cmt" Text='<%#Eval("Skiv_no") %>'
         CommandArgument='<%#Eval("Skiv_no") %>' CommandName="Kommentar" />
      </ItemTemplate>        
      <HeaderStyle CssClass="cmt_align" />
      <ItemStyle CssClass="grid_style" />
   </asp:TemplateField>
                                  
                               
                                        
    <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
        <HeaderTemplate>
           <asp:LinkButton ID="lnkbtnInm_dat" runat="server" CommandName="Sort" 
            ForeColor="#F7F7F7" CommandArgument="Inm_dat" OnCommand="SortInkop_Command">
            InmDat</asp:LinkButton>
        </HeaderTemplate>
        <ItemTemplate>
           <asp:Label ID="lblSortInm_dat" runat="server" Text='<%# Eval("Inm_dat", "{0:yyyy-MM-dd}") %>'
           EnableTheming="false" >
           </asp:Label>                                      
        </ItemTemplate>
        <ItemStyle CssClass="grid_style" />             
   </asp:TemplateField> 
                                        
                                        
                                        
     <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
        <HeaderTemplate>
            <asp:LinkButton ID="lnkbtnKop_grad" runat="server" CommandName="Sort" 
            ForeColor="#F7F7F7" CommandArgument="Kop_grad" OnCommand="SortInkop_Command">
            Kgrad</asp:LinkButton>
        </HeaderTemplate>
        <ItemTemplate>
           <asp:Label ID="lblSortKop_grad" runat="server" Text='<%# Eval("Kop_grad") %>'
           EnableTheming="false" >
           </asp:Label>                                      
        </ItemTemplate>
        <ItemStyle CssClass="grid_style" />             
    </asp:TemplateField> 
                                       
                                       
                                       
   <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
      <HeaderTemplate>
         <asp:LinkButton ID="lnkbtnKop_kat" runat="server" CommandName="Sort" 
         ForeColor="#F7F7F7" CommandArgument="Kop_kat" OnCommand="SortInkop_Command">
         Kkat</asp:LinkButton>
      </HeaderTemplate>
      <ItemTemplate>
         <asp:Label ID="lblSortKop_kat" runat="server" Text='<%# Eval("Kop_kat") %>'
         EnableTheming="false" >
         </asp:Label>                                      
      </ItemTemplate>
      <ItemStyle CssClass="grid_style" />             
  </asp:TemplateField> 
                                     
                                     
                                     
                                     
   <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
      <HeaderTemplate>
         <asp:LinkButton ID="lnkbtnCa_pris" runat="server" CommandName="Sort" 
         ForeColor="#F7F7F7" CommandArgument="Ca_pris" OnCommand="SortInkop_Command">
         Capris</asp:LinkButton>
     </HeaderTemplate>
     <ItemTemplate>
       <asp:Label ID="lblSortCa_pris" runat="server" Text='<%# Eval("Ca_pris") %>'
       EnableTheming="false" >
       </asp:Label>                                      
    </ItemTemplate>
    <ItemStyle CssClass="grid_style" />             
  </asp:TemplateField> 
                                       
                                       
                                       
                                       
    </Columns>
                                        
</asp:GridView>

