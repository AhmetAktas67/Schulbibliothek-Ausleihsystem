using Xunit;
using SchulbibliothekWpf.Models;
using System;

public class BibliothekTests
{
    [Fact]
    public void Buch_hat_gueltigen_Titel()
    {
        var buch = new Buch { Titel = "Testbuch" };
        Assert.False(string.IsNullOrWhiteSpace(buch.Titel));
    }

    [Fact]
    public void Benutzer_hat_Rolle()
    {
        var benutzer = new Benutzer { Rolle = "Schüler" };
        Assert.Equal("Schüler", benutzer.Rolle);
    }

    [Fact]
    public void Ausleihe_ist_nicht_ueberfaellig_am_ersten_Tag()
    {
        var ausleihe = new Ausleihe
        {
            DatumAusleihe = DateTime.Now
        };

        Assert.Equal(0, ausleihe.TageImVerzug);
    }

    [Fact]
    public void Ausleihe_ist_ueberfaellig_nach_14_Tagen()
    {
        var ausleihe = new Ausleihe
        {
            DatumAusleihe = DateTime.Now.AddDays(-20)
        };

        Assert.True(ausleihe.TageImVerzug > 0);
    }

    [Fact]
    public void BuchID_muss_groesser_0_sein()
    {
        var buch = new Buch { BuchID = 1 };
        Assert.True(buch.BuchID > 0);
    }
}