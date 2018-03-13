    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" validateRequest=false %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SkivorNETClient</title>

<!-- JavaScipt: -->
<script type="text/javascript" src="javascript/browser.js"></script>
<script type="text/javascript" src="javascript/datum.js"></script>

</head>
<body onload="datum(); setInterval('datum()', 1000 )">
    <form id="form1" runat="server">
    
    <div id="container">
        
       
           
           <div id="header">
           
                <!--Datumruta; Visning av Datum och tid: -->
                <div id="datumruta">

                <div id="clock">&nbsp;</div>

                </div>
           
           
           </div>
           
           
           
           
           
        <div id="content">
    
              <!-- Display-ram börjar: -->
              <div class="ruta">
                 
                 
                 <!--Panel att "skriva" till: -->
                <asp:Panel ID="frame" runat="server">
                   
                      <!-- För att visa information/data som skall stå över kontroll: -->
                      <span id="display" runat="server" class="mess"></span>
                         
                         
                           <!-- GridView för att visa artistdata (i usercontrol): -->
                         <TF:UGridResult_Artist ID="grdResult_Artist_UCtrl"  Visible="true" runat="server" />
                         
                         <!-- GridView för att visa resultat från Hämta-funktion och sökning (i usercontrol): -->
                         <TF:UGridArtistdata_Artist ID="grd_Artistdata_Artist_UCtrl" Visible="true" runat="server" />
                         
                         <!-- GridView som visar hel tabell inkl paging etc: -->
                        <TF:UGridArtister_Artist ID="gridArtister_Artist_UCtrl" Visible="true" runat="server" />
                     
                        
                   <!-- För att visa information/data som skall stå under kontroll: -->
                   <span id="display2" runat="server" class="mess"></span>
                      
                </asp:Panel>
                    
                    
            <!--Slut på display-ram:  -->
          </div>
       
             
    </div>
             
            
             
             
    <div id="navigation">
               
         <asp:Panel ID="pnlEnterDataEnter" runat="server" DefaultButton="button_sok">  
               
         
               <!--Labels RAD1: -->
               
               <asp:Label  CssClass="label1 move" ID="label1_Artist" runat="server" Text="Artist"></asp:Label>
               
               <asp:Label  CssClass="label1 move" ID="label2_Album" runat="server" Text="Titel"></asp:Label>
               
               <asp:Label  CssClass="label1 move" ID="label3_Format" runat="server" Text="Format"></asp:Label>
               
               <asp:Label  CssClass="label1 move" ID="label4_Press" runat="server" Text="Press"></asp:Label>
               
               <asp:Label  CssClass="label1 move" ID="label5_Kommentar" runat="server" Text="Kommentar"></asp:Label>
               
               <asp:Label  CssClass="label1 move" ID="label6_ar" runat="server" Text="År"></asp:Label>
               
               
               
             <!--Textrutor RAD1: -->
               
               <asp:TextBox CssClass="move text1" ID="text3_Artist" MaxLength="50" 
                   runat="server" Size="15"></asp:TextBox>
                   
                   
               <asp:TextBox CssClass="move text1" ID="text4_Album" MaxLength="80" runat="server" Size="15"></asp:TextBox>
               
               <asp:DropDownList CssClass="move text1" ID="text5_Format"  runat="server" Size="1">
                    <asp:ListItem />
                    <asp:ListItem Value="CD" />
                        <asp:ListItem Value="CDM" />
                        <asp:ListItem Value="CDS" />
                        <asp:ListItem Value="2CD" />
                        <asp:ListItem Value="LCDM" />
                        <asp:ListItem Value="XLCDM" />
                        <asp:ListItem Value="DVDS" />
                        <asp:ListItem Value="CD+DVD" />
                        <asp:ListItem Value="DVD/SACD" />
                        <asp:ListItem Value="CDM/DVD" />
                        <asp:ListItem Value="dEP" />
                        <asp:ListItem Value="LP" />
                        <asp:ListItem Value="2LP" />
                        <asp:ListItem Value="BOX" /> 
                        <asp:ListItem Value="12" />
                        <asp:ListItem Value="L12" />
                        <asp:ListItem Value="XL12" />
                        <asp:ListItem Value="L12num" />
                        <asp:ListItem Value="TwinSetL12" />
                        <asp:ListItem Value="TwinSetL12num" />
                        <asp:ListItem Value="Promo" />
                        <asp:ListItem Value="7" />
                        <asp:ListItem Value="aEP" />
                        <asp:ListItem Value="mp3" />
                   </asp:DropDownList>
               
               <asp:DropDownList CssClass="move text1" ID="text6_Press"  runat="server" Size="1">
                    <asp:ListItem />
                    <asp:ListItem Value="at" />
                      <asp:ListItem Value="be" />
                      <asp:ListItem Value="ca" />
                      <asp:ListItem Value="de" />
                      <asp:ListItem Value="dk" />
                      <asp:ListItem Value="eu" />
                      <asp:ListItem Value="fr" />
                      <asp:ListItem Value="holl" />
                      <asp:ListItem Value="it" />
                      <asp:ListItem Value="se" />
                      <asp:ListItem Value="uk" />
                      <asp:ListItem Value="ukorg" />
                      <asp:ListItem Value="us" />
               </asp:DropDownList>
               
               
               <asp:DropDownList CssClass="move text1" ID="text8_ar"  runat="server" Size="1">
                    <asp:ListItem />
                    <asp:ListItem Value="1965" />
                    <asp:ListItem Value="1966" />
                     <asp:ListItem Value="1967" />
                     <asp:ListItem Value="1968" />
                     <asp:ListItem Value="1969" />
                     <asp:ListItem Value="1970" />
                     <asp:ListItem Value="1971" />
                     <asp:ListItem Value="1972" />
                     <asp:ListItem Value="1973" />
                     <asp:ListItem Value="1974" />
                     <asp:ListItem Value="1975" />
                     <asp:ListItem Value="1976" />
                     <asp:ListItem Value="1977" />
                     <asp:ListItem Value="1978" />
                     <asp:ListItem Value="1979" />
                     <asp:ListItem Value="1980" />
                     <asp:ListItem Value="1981" />
                     <asp:ListItem Value="1982" />
                     <asp:ListItem Value="1983" />
                     <asp:ListItem Value="1984" />
                     <asp:ListItem Value="1985" />
                     <asp:ListItem Value="1986" />
                     <asp:ListItem Value="1987" />
                     <asp:ListItem Value="1988" />
                     <asp:ListItem Value="1989" />
                     <asp:ListItem Value="1990" />
                     <asp:ListItem Value="1991" />
                     <asp:ListItem Value="1992" />
                     <asp:ListItem Value="1993" />
                     <asp:ListItem Value="1994" />
                     <asp:ListItem Value="1995" />
                     <asp:ListItem Value="1996" />
                     <asp:ListItem Value="1997" />
                     <asp:ListItem Value="1998" />
                     <asp:ListItem Value="1999" />
                     <asp:ListItem Value="2000" />
                     <asp:ListItem Value="2001" />
                     <asp:ListItem Value="2002" />
                     <asp:ListItem Value="2003" />
                     <asp:ListItem Value="2004" />
                     <asp:ListItem Value="2005" />
                     <asp:ListItem Value="2006" />
                     <asp:ListItem Value="2007" />
                     <asp:ListItem Value="2008" />
                     <asp:ListItem Value="2009" />
                     <asp:ListItem Value="2010" />
                     <asp:ListItem Value="2011" />
                     <asp:ListItem Value="2012" />
                     <asp:ListItem Value="2013" />
                     <asp:ListItem Value="2014" />
                     <asp:ListItem Value="2015" />
                     <asp:ListItem Value="2016" />
                     <asp:ListItem Value="2017" />
                     <asp:ListItem Value="2018" />
                     <asp:ListItem Value="2019" />
                     <asp:ListItem Value="2020" />
                    
               </asp:DropDownList>
               
               <asp:TextBox CssClass="move text1" ID="text7_Kommentar" MaxLength="1000" runat="server" Size="15"></asp:TextBox>
               
               
               
              <!--Labels RAD2: -->
               
               <asp:Label  CssClass="label2 move" ID="label7_VPfr" runat="server" Text="VPfr"></asp:Label>
               
               <asp:Label  CssClass="label2 move" ID="label8_VPtill" runat="server" Text="VPtill"></asp:Label>
               
               <asp:Label  CssClass="label2 move" ID="label9_Ursland" runat="server" Text="Ursland"></asp:Label>
               
               <asp:Label  CssClass="label2 move" ID="label10_Ursstad" runat="server" Text="Ursstad"></asp:Label>
               
               <asp:Label  CssClass="label2 move" ID="label11_Musiktyp" runat="server" Text="Musiktyp"></asp:Label>
               
               
               
               
               <!--Textrutor RAD2: -->
               
               <asp:DropDownList CssClass="move text2" ID="text9_VPfr"  runat="server" Size="1">
                    <asp:ListItem />
                    <asp:ListItem Value="1965" />
                    <asp:ListItem Value="1966" />
                     <asp:ListItem Value="1967" />
                     <asp:ListItem Value="1968" />
                     <asp:ListItem Value="1969" />
                     <asp:ListItem Value="1970" />
                     <asp:ListItem Value="1971" />
                     <asp:ListItem Value="1972" />
                     <asp:ListItem Value="1973" />
                     <asp:ListItem Value="1974" />
                     <asp:ListItem Value="1975" />
                     <asp:ListItem Value="1976" />
                     <asp:ListItem Value="1977" />
                     <asp:ListItem Value="1978" />
                     <asp:ListItem Value="1979" />
                     <asp:ListItem Value="1980" />
                     <asp:ListItem Value="1981" />
                     <asp:ListItem Value="1982" />
                     <asp:ListItem Value="1983" />
                     <asp:ListItem Value="1984" />
                     <asp:ListItem Value="1985" />
                     <asp:ListItem Value="1986" />
                     <asp:ListItem Value="1987" />
                     <asp:ListItem Value="1988" />
                     <asp:ListItem Value="1989" />
                     <asp:ListItem Value="1990" />
                     <asp:ListItem Value="1991" />
                     <asp:ListItem Value="1992" />
                     <asp:ListItem Value="1993" />
                     <asp:ListItem Value="1994" />
                     <asp:ListItem Value="1995" />
                     <asp:ListItem Value="1996" />
                     <asp:ListItem Value="1997" />
                     <asp:ListItem Value="1998" />
                     <asp:ListItem Value="1999" />
                     <asp:ListItem Value="2000" />
                     <asp:ListItem Value="2001" />
                     <asp:ListItem Value="2002" />
                     <asp:ListItem Value="2003" />
                     <asp:ListItem Value="2004" />
                     <asp:ListItem Value="2005" />
                     <asp:ListItem Value="2006" />
                     <asp:ListItem Value="2007" />
                     <asp:ListItem Value="2008" />
                     <asp:ListItem Value="2009" />
                     <asp:ListItem Value="2010" />
                     <asp:ListItem Value="2011" />
                     <asp:ListItem Value="2012" />
                     <asp:ListItem Value="2013" />
                     <asp:ListItem Value="2014" />
                     <asp:ListItem Value="2015" />
                     <asp:ListItem Value="2016" />
                     <asp:ListItem Value="2017" />
                     <asp:ListItem Value="2018" />
                     <asp:ListItem Value="2019" />
                     <asp:ListItem Value="2020" />
               </asp:DropDownList>
               
               <asp:DropDownList CssClass="move text2" ID="text10_VPtill"  runat="server" Size="1">
                    <asp:ListItem />
                    <asp:ListItem Value="active" />
                    <asp:ListItem Value="1965" />
                    <asp:ListItem Value="1966" />
                     <asp:ListItem Value="1967" />
                     <asp:ListItem Value="1968" />
                     <asp:ListItem Value="1969" />
                     <asp:ListItem Value="1970" />
                     <asp:ListItem Value="1971" />
                     <asp:ListItem Value="1972" />
                     <asp:ListItem Value="1973" />
                     <asp:ListItem Value="1974" />
                     <asp:ListItem Value="1975" />
                     <asp:ListItem Value="1976" />
                     <asp:ListItem Value="1977" />
                     <asp:ListItem Value="1978" />
                     <asp:ListItem Value="1979" />
                     <asp:ListItem Value="1980" />
                     <asp:ListItem Value="1981" />
                     <asp:ListItem Value="1982" />
                     <asp:ListItem Value="1983" />
                     <asp:ListItem Value="1984" />
                     <asp:ListItem Value="1985" />
                     <asp:ListItem Value="1986" />
                     <asp:ListItem Value="1987" />
                     <asp:ListItem Value="1988" />
                     <asp:ListItem Value="1989" />
                     <asp:ListItem Value="1990" />
                     <asp:ListItem Value="1991" />
                     <asp:ListItem Value="1992" />
                     <asp:ListItem Value="1993" />
                     <asp:ListItem Value="1994" />
                     <asp:ListItem Value="1995" />
                     <asp:ListItem Value="1996" />
                     <asp:ListItem Value="1997" />
                     <asp:ListItem Value="1998" />
                     <asp:ListItem Value="1999" />
                     <asp:ListItem Value="2000" />
                     <asp:ListItem Value="2001" />
                     <asp:ListItem Value="2002" />
                     <asp:ListItem Value="2003" />
                     <asp:ListItem Value="2004" />
                     <asp:ListItem Value="2005" />
                     <asp:ListItem Value="2006" />
                     <asp:ListItem Value="2007" />
                     <asp:ListItem Value="2008" />
                     <asp:ListItem Value="2009" />
                     <asp:ListItem Value="2010" />
                     <asp:ListItem Value="2011" />
                     <asp:ListItem Value="2012" />
                     <asp:ListItem Value="2013" />
                     <asp:ListItem Value="2014" />
                     <asp:ListItem Value="2015" />
                     <asp:ListItem Value="2016" />
                     <asp:ListItem Value="2017" />
                     <asp:ListItem Value="2018" />
                     <asp:ListItem Value="2019" />
                     <asp:ListItem Value="2020" />
               </asp:DropDownList>
               
               <asp:DropDownList CssClass="move text2" ID="text11_Ursland" runat="server" Size="1">
               <asp:ListItem />
               <asp:ListItem Value="at" />
                      <asp:ListItem Value="be" />
                      <asp:ListItem Value="ca" />
                      <asp:ListItem Value="de" />
                      <asp:ListItem Value="dk" />
                      <asp:ListItem Value="eu" />
                      <asp:ListItem Value="fr" />
                      <asp:ListItem Value="holl" />
                      <asp:ListItem Value="it" />
                      <asp:ListItem Value="se" />
                      <asp:ListItem Value="uk" />
                      <asp:ListItem Value="ukorg" />
                      <asp:ListItem Value="us" />
               </asp:DropDownList>
               
               <asp:TextBox CssClass="move text2" ID="text12_Ursstad" MaxLength="50" runat="server" Size="6"></asp:TextBox>
               
                    <asp:RegularExpressionValidator id="vldArtistOnlyLetters" runat="server"
                    Display="None" ValidationExpression="^[a-öA-Ö\s.]*$"
                    ControlToValidate="text12_Ursstad"  Enabled="true" 
                    EnableClientScript="false"  ValidationGroup="x"/>
                    
                <asp:DropDownList CssClass="move text2" ID="text13_Musiktyp" runat="server" Size="1">
               <asp:ListItem />
               <asp:ListItem Value="Cyberpunk" />
               <asp:ListItem Value="EBM" />
               <asp:ListItem Value="EuroDisco" />
               <asp:ListItem Value="Gothrock" />
               <asp:ListItem Value="HipHop" />
               <asp:ListItem Value="Industri" />
               <asp:ListItem Value="New Wave" />
               <asp:ListItem Value="Pop" />
               <asp:ListItem Value="Punk" />
               <asp:ListItem Value="RnB" />
               <asp:ListItem Value="Rock" />
               <asp:ListItem Value="Synth" />
               <asp:ListItem Value="Synthpop" />
               </asp:DropDownList>
               
               
                   
                   
               
               
                <!--Knappar RAD1: --> 
                
               <asp:Button ID="button_visa_databas" runat="server" 
                CssClass="input move rad1" Text="Visa_TB" 
                   onclick="button_visa_databas_Click"  
                   CausesValidation="False" />
                   
               
                
               <asp:Button ID="button_sok" runat="server" 
                CssClass="input move rad1" Text="Sök" 
                 onclick="button_sok_Click"  
                 CausesValidation="true" ValidationGroup="x" />
                   
                   
                   <asp:Button ID="button_info" runat="server" 
                CssClass="input move rad1" Text="HOLDER" 
                   CausesValidation="False"/>       
                   
                   
                    <asp:Button ID="button_Borja_om" runat="server" 
                CssClass="input move rad1" Text="Börja_om" 
                OnClientClick="this.form.reset();return false;" 
                   onclick="button_Borja_om_Click" 
                   CausesValidation="False" />
                   
                   
                  <asp:Button ID="button_Refresh" runat="server" 
                CssClass="input move rad1" Text="Omstart_TB" 
                   onclick="button_Refresh_TB_Click" 
                   CausesValidation="False" />
                    
                 
                   
                   
                   
         <!-- Tabellvals-radioknappar inkl. labels (i form av div): -->
           
           <div  class="label3 move" id="label13_TBskivor">Skivtabell</div>
           
           <asp:RadioButton ID="optSkivtabell" runat="server" GroupName="radioval"  TextAlign="Right"   
           AutoPostBack="true" CssClass="optSkivtabell" Checked="false"
            OnCheckedChanged="Skivtabell_CheckedChanged" />        
           
           <div class="label3 move" id="label14_TBartist">Artisttabell</div>
           <asp:RadioButton ID="optArtisttabell" runat="server" GroupName="radioval" TextAlign="Right"
           AutoPostBack="true" CssClass="optArtisttabell" OnCheckedChanged="Artisttabell_CheckedChanged" 
             Checked="true" />
           
           
         </asp:Panel>  
        
        
      </div>  
           
         
   
           
     </div>
    </form>
</body>
</html> 
                                            
                                             
                                             