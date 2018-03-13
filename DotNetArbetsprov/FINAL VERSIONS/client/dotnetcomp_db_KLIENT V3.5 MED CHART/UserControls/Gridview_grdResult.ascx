<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Gridview_grdResult.ascx.cs" Inherits="UserControls_Gridview_grdResult" %>



<!-- GridView för att visa resultat från sökning: -->



<asp:GridView ID="grdResult" runat="server" BackColor="White" AllowPaging="true" PageSize="6" 
    AllowSorting="false" OnRowCommand="gridResult_RowCommand" 
    HeaderStyle-CssClass="header" OnPageIndexChanging="grdResult_PageIndexChanging"> 
                                   
                                          
                            
    <Columns>
                          
                                    
                                    
      <asp:TemplateField ItemStyle-CssClass="grid_style"
      SortExpression="Artist" HeaderStyle-CssClass="pos_grdresult">
                                          
         <HeaderTemplate>
             <asp:LinkButton ID="lnkbtnArtist" runat="server" CommandName="Sort" 
              ForeColor="#F7F7F7" CommandArgument="Artist" OnCommand="SortSkivor_Command">
              Artist</asp:LinkButton>
         </HeaderTemplate>
         <ItemTemplate>
              <asp:Button ID="Artist" runat="server" CssClass="arti" Text='<%#Eval("Artist") %>'
              CommandArgument='<%#Eval("Artist_no") %>' CommandName="Artist" 
              OnCommand="SortSkivor_Command" />
         </ItemTemplate>        
         <ItemStyle CssClass="grid_style" />
    </asp:TemplateField>
                                          
                                          
                                    
   <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
       <HeaderTemplate>
           <asp:LinkButton ID="lnkbtnAlbum" runat="server" CommandName="Sort" 
           ForeColor="#F7F7F7" CommandArgument="Album" OnCommand="SortSkivor_Command">
           Titel</asp:LinkButton>
       </HeaderTemplate>
       <ItemTemplate>
          <asp:Label ID="lblSortArtist" runat="server" Text='<%# Eval("Album") %>'
          EnableTheming="false">
          </asp:Label>                                      
      </ItemTemplate>
      <ItemStyle CssClass="grid_style" />             
  </asp:TemplateField> 
                                      
                                      
  <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
     <HeaderTemplate>
        <asp:LinkButton ID="lnkbtnFormat" runat="server" CommandName="Sort" 
        ForeColor="#F7F7F7" CommandArgument="Format" OnCommand="SortSkivor_Command">
        Format</asp:LinkButton>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lblSortFormat" runat="server" Text='<%# Eval("Format") %>'
        EnableTheming="false">
        </asp:Label>                                      
    </ItemTemplate>
    <ItemStyle CssClass="grid_style" />             
 </asp:TemplateField> 
                                       
                                       
 <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
    <HeaderTemplate>
      <asp:LinkButton ID="lnkbtnPress" runat="server" CommandName="Sort" 
      ForeColor="#F7F7F7" CommandArgument="Press" OnCommand="SortSkivor_Command">
      Press</asp:LinkButton>
   </HeaderTemplate>
   <ItemTemplate>
      <asp:Label ID="lblSortPress" runat="server" Text='<%# Eval("Press") %>'
      EnableTheming="false">
      </asp:Label>                                      
   </ItemTemplate>
   <ItemStyle CssClass="grid_style" />             
</asp:TemplateField> 
                                         
                                      
                                      
  <asp:TemplateField ItemStyle-CssClass="grid_style" HeaderStyle-CssClass="pos_grdresult">
     <HeaderTemplate>
        <asp:LinkButton ID="lnkbtnAr" runat="server" CommandName="Sort" 
        ForeColor="#F7F7F7" CommandArgument="Ar" OnCommand="SortSkivor_Command">
        År</asp:LinkButton>
     </HeaderTemplate>
     <ItemTemplate>
        <asp:Label ID="lblSortAr" runat="server" Text='<%# Eval("Ar") %>'
        EnableTheming="false">
        </asp:Label>                                      
     </ItemTemplate>
     <ItemStyle CssClass="grid_style" />             
 </asp:TemplateField> 
                                       
                                       
   <asp:TemplateField  HeaderText="Komtr" HeaderStyle-CssClass="cmt_align" 
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
                        
                       










