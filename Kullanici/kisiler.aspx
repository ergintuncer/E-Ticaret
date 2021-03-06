﻿<%@ Page Title="Kişi işlemleri" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="kisiler.aspx.cs" Inherits="Kullanici_kisiler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="pageDisDiv">
<div class="ustDiv">
    <asp:ScriptManager ID="MainScriptManager" runat="server"/>
    <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
        <ContentTemplate>
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label  Font-Bold="True"  runat="server" Text="Yeni Kişi Ekle" Font-Size="200%">Yeni kişi ekle</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtAdi" CssClass="TexBoxCss" runat="server" MaxLength="50" AutoCompleteType="FirstName"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Soyadı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtSoyadi" CssClass="TexBoxCss" runat="server" MaxLength="50" AutoCompleteType="LastName"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label Font-Bold="True" runat="server">TC No: </asp:Label>
                </div>
                <div class="lineSagDiv">

                    <asp:TextBox ID="txtTcNo" CssClass="TexBoxCss" TextMode="Number" MaxLength="11" OnTextChanged="tcNo_OnTextChanged" AutoPostBack="True" runat="server"></asp:TextBox>
                    <br/> <asp:Label ID="lblOnTextChanged" runat="server" Visible="False" ForeColor="#F50057"></asp:Label>

                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Kişi Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpKisiTuru" runat="server" CssClass="drplist" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">İl:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpIl" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpIl_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">İlçe:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpIlce" runat="server" CssClass="drplist" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Telefon Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtTelefonAdi" CssClass="TexBoxCss" runat="server" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Telefon No:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtTelefonNo" CssClass="TexBoxCss" runat="server" TextMode="Phone" MaxLength="11"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Mail:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtMail" CssClass="TexBoxCss" runat="server" TextMode="Email" MaxLength="100" AutoCompleteType="Email"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Bakiye:</asp:Label>
                </div>
                <div class="lineSagDiv">
                <asp:TextBox ID="txtBakiye" CssClass="TexBoxCss" runat="server" TextMode="Number" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Adres Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtAdresAdi" CssClass="TexBoxCss" runat="server" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label  Font-Bold="True"  runat="server">Adres:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtAdres" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine" MaxLength="250" AutoCompleteType="HomeStreetAddress"></asp:TextBox>
                </div>
            </div>
            <div class="lineOrta">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdi" ErrorMessage="İsim Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoyadi" ErrorMessage="Soyisim Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTcNo" ErrorMessage="Tc Kimlik Numarası Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelefonAdi" ErrorMessage="Telefon Adı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelefonNo" ErrorMessage="Telefon Numarası Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBakiye" ErrorMessage="Bakiye Alanı boş olamaz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAdresAdi" ErrorMessage="Adres adı boş olamaz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAdres" ErrorMessage="Adres boş olamaz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="validationSummary"/>
            </div>
            <div class="alert alert-success alert-dismissible fade show" role="alert" id="successalert" runat="server" Visible="False">
                Kayıt Ekleme işlemi başarı ile tamalandı.
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="alert alert-danger alert-dismissible fade show" role="alert" id="dangeralert" runat="server" Visible="False">
                Hay aksi. Bir hata oluştu.
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="lineOrta">
                <asp:Button runat="server" ID="btnKaydet" class="btn btn-outline-success" OnClick="btnKaydet_Click" Text="Kaydet"/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>


<div class="altDiv">
    <div class="line" style="position: sticky; background-color: white; padding-left: 30%; border-bottom: solid silver thin; padding-bottom: 0.5%;" data-spy="affix">
        <div class="input-group" style="width: 50%; text-align: center;">
            <input type="text" class="form-control" placeholder="Kişilerde ara..." aria-label="Kişi Adı Yazınız.." runat="server" id="txtAra"/>
            <span class="input-group-btn">
                <button class="btn btn-info" CausesValidation="False" type="button" runat="server" ID="btnAra" OnServerClick="btnAra_Click">Ara!</button>
            </span>
        </div>
    </div>
    <asp:ListView ID="list2" runat="server">
        <ItemTemplate>
            <div class="ListeDiv">
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Adı: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblil" runat="server" Text='<%#Eval("ad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Soyadı: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblilce" runat="server" Text='<%#Eval("soyad") %>'></asp:Label>

                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Tc No: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lbladresadi" runat="server" Text='<%#Eval("tck") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">E-Mail: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("mail") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">İl: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lbladres" runat="server" Text='<%#Eval("il") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">İlçe: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblaciklama" runat="server" Text='<%#Eval("ilce") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Telefon Adı: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("telefonad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Telefon No: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblaktif" runat="server" Text='<%#Eval("telefon") %>'></asp:Label>
                    </div>
                </div>

                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Kişi Türü: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("kisiturad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Bakiye: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("kisibakiye") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Adres Adı: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("adresad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label  Font-Bold="True"  runat="server">Adres: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("adres") %>'></asp:Label>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
</div>

</asp:Content>