using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using OdrzavanjePuteva.Entiteti;
using OdrzavanjePuteva.Mapiranja;

namespace OdrzavanjePuteva
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdPrikaziVozilo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                OdrzavanjePuteva.Entiteti.Vozilo p = s.Load<OdrzavanjePuteva.Entiteti.Vozilo>(42);

                MessageBox.Show(p.Boja);


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajIzvrsioca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Izvrsilac p = new Entiteti.Izvrsilac();
                
                    p.Adresa = "Rasinska 645";
                    p.DatumPostavljanja = DateTime.Today;
                    p.Ime = "Marko";
                    p.Jmbg = "1743397685400";
                    p.Prezime = "Markovic";
                    //p.Tip_Radnika = "izvrsilac";
                    p.Specijalnost = "kolovoz";
                    p.Id_Nadredjenog = 1;
                    p.Godina_Rodj = "1990";
                    p.Ime_Oca = "Stefan";
                

                OdrzavanjePuteva.Entiteti.Deonica d = s.Load<OdrzavanjePuteva.Entiteti.Deonica>(3);
                p.Deonice.Add(d);

                OdrzavanjePuteva.Entiteti.Vozilo v = s.Load<OdrzavanjePuteva.Entiteti.Vozilo>(4);
                Upravlja u = new Upravlja();
                u.Pocetak = DateTime.Today;
                u.Kraj = DateTime.Today;

                u.Izvrsilac = p;
                u.Vozilo = v;
                p.UpravljaVozilima.Add(u);

              

                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajVozilo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s1 = DataLayer.GetSession();

                Putnicka o = s1.Load<Putnicka>(1);


                o.TipGoriva = "benzin";

                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajUpit_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Radnik");
                //q.AddEntity(typeof(Radnik));
                IList<Radnik> radnici = q.List<Radnik>();
                q.SetFirstResult(5);
                q.SetMaxResults(10);

                foreach(Radnik r in radnici)
                {
                    MessageBox.Show(r.Adresa);
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajSpoljnog_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.SpoljniSaradnik p = new Entiteti.SpoljniSaradnik();
                Radnik o = s.Load<Radnik>(33);
                p.BrojUgovora = 257;
                p.Nadzornik = o;


                s.Save(p);

                s.Flush();
                s.Close();
            }

            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdObrisiRadnika_Click(object sender, EventArgs e)
        {
            try
            {

                Radnik r = ucitajRadnika();
                ISession s1 = DataLayer.GetSession();
                s1.Delete(r);


                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        Radnik ucitajRadnika()
        {
            ISession s = DataLayer.GetSession();

            Radnik o = s.Load<Radnik>(91);
            MessageBox.Show(o.Ime);


            s.Flush();
            s.Close();
            return o;
        }

        private void cmdKreirajGradiliste_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Gradiliste p = new Entiteti.Gradiliste();
                p.TipGradilista = "Put";
                OdrzavanjePuteva.Entiteti.Deonica d = s.Load<OdrzavanjePuteva.Entiteti.Deonica>(21);
                p.Deonice.Add(d);
                OdrzavanjePuteva.Entiteti.Deonica d1 = s.Load<OdrzavanjePuteva.Entiteti.Deonica>(22);
                p.Deonice.Add(d1);
                OdrzavanjePuteva.Entiteti.Deonica d2 = s.Load<OdrzavanjePuteva.Entiteti.Deonica>(23);
                p.Deonice.Add(d2);
               // OdrzavanjePuteva.Entiteti.Deonica d3 = s.Load<OdrzavanjePuteva.Entiteti.Deonica>(5);
               // p.Deonice.Add(d3);

                s.Save(p);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajDeonicu_Click(object sender, EventArgs e)
        {
            ISession s = DataLayer.GetSession();

            Deonica d = new Deonica();
            d.Grad1 = "Nis";
            d.Grad2 = "Prokuplje";
            d.DoKilometra = 5;
            d.OdKilometra = 1;
            OdrzavanjePuteva.Entiteti.Gradiliste p = s.Load<Gradiliste>(1);
            d.Gradiliste = p;
            OdrzavanjePuteva.Entiteti.Izvrsilac r = s.Load<Izvrsilac>(54);
            d.Izvrsilac = r;
            s.Save(d);

            Entiteti.RadneMasine v = new Entiteti.RadneMasine();
            v.Registracija = "VR3378";
            v.TipGoriva = "kerozin";
            v.Boja = "bela";
            v.ZapreminaMotora = 3000;
            v.TipPogonaRadneMasine = "tockas";
            v.TipRadneMasine = "rovokopac";
            s.Save(v);

            AngazovanjeRM a = new AngazovanjeRM();
            a.Pocetak = DateTime.Parse("21-OCT-17");
            a.Kraj = DateTime.Parse("21-NOV-17");
            a.Deonica = d;
            a.RadnaMasina = v;
            s.Save(a);

            v.AngazovaneRM.Add(a);
            d.AngazovaneRM.Add(a);
            s.Save(d);
            s.Save(v);

            s.Flush();
            s.Close();
        
        }

        private void cmdObrisiGradiliste_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Gradiliste o = s.Load<Gradiliste>(4);


                s.Delete(o);


                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiDeonicu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Deonica o = s.Load<Deonica>(4);


                s.Delete(o);


                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajRadnika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s1 = DataLayer.GetSession();

                Radnik o = s1.Load<Radnik>(54);

                o.DatumPostavljanja = DateTime.Parse("03-MAY-2017");
                Radnik v = s1.Load<Radnik>(6);
                o.Id_Nadredjenog = v.Id_Radnika;

                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikaziDeonicu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                OdrzavanjePuteva.Entiteti.Deonica p = s.Load<OdrzavanjePuteva.Entiteti.Deonica>(41);

                MessageBox.Show(p.Grad1);

                foreach (Entiteti.AngazovanjeRM d in p.AngazovaneRM)
                {
                    MessageBox.Show(d.Pocetak.ToString());
                    MessageBox.Show(d.RadnaMasina.TipGoriva);

                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikaziUpravlja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Upravlja o = s.Load<Upravlja>(5);

                MessageBox.Show(o.Pocetak.ToString());

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikaziAngazovaneT_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                AngazovanjeT o = s.Load<AngazovanjeT>(5);

                MessageBox.Show(o.Pocetak.ToString());

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikaziSpoljnog_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();

                SpoljniSaradnik o = s.Load<SpoljniSaradnik>(5);

                MessageBox.Show(o.BrojUgovora.ToString());

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajVozilo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Putnicka p = new Entiteti.Putnicka();

                p.Registracija = "LE180PG";
                p.TipGoriva = "dizel";
                p.Boja = "zelena";

                p.ZapreminaMotora = 4000;
                p.BrojMesta = 4;

                s.Save(p);


                OdrzavanjePuteva.Entiteti.Radnik r = s.Load<OdrzavanjePuteva.Entiteti.Radnik>(92);

                Vozi v1 = new Vozi();
                v1.Pocetak = DateTime.Today;
                v1.Kraj = DateTime.Today;

                v1.Nadzornik = r;
                v1.Vozilo = p;
                r.VozeVozila.Add(v1);
                p.RadniciVoze.Add(v1);


                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdObrisiVozilo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Vozilo o = s.Load<Vozilo>(42);


                s.Delete(o);


                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajVozi_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OdrzavanjePuteva.Entiteti.Radnik p = s.Load<OdrzavanjePuteva.Entiteti.Radnik>(54);

                OdrzavanjePuteva.Entiteti.Vozilo v = s.Load<OdrzavanjePuteva.Entiteti.Vozilo>(42);
                Vozi v1 = new Vozi();
                v1.Pocetak = DateTime.Today;
                v1.Kraj = DateTime.Today;

                v1.Nadzornik = p;
                v1.Vozilo = v;
                p.VozeVozila.Add(v1);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajNadzornika_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Nadzornik p = new Entiteti.Nadzornik();

                p.Adresa = "Martovska 8";
                p.DatumPostavljanja = DateTime.Parse("20-FEB-19");
                p.Ime = "Jordan";
                p.Jmbg = "1102997685410";
                p.Prezime = "Jovcev";
                //p.TipRadnika = "nadzornik";
                p.Id_Nadredjenog = 1;
                p.Godina_Rodj = "1965";
                p.Ime_Oca = "Mitka";
                s.Save(p);

                SpoljniSaradnik ss = new SpoljniSaradnik();
                ss.BrojUgovora = 511;
                ss.Nadzornik = p;
                s.Save(ss);

                OdrzavanjePuteva.Entiteti.Vozilo v = s.Load<OdrzavanjePuteva.Entiteti.Vozilo>(4);
                Vozi u = new Vozi();
                u.Pocetak = DateTime.Today;
                u.Kraj = DateTime.Today;

                u.Nadzornik = p;
                u.Vozilo = v;
                p.VozeVozila.Add(u);
                v.RadniciVoze.Add(u);

                //s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajUpit2_Click(object sender, EventArgs e)
        {
            try
            {

                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Radnik as r where r.Godina_Rodj > ?" +
                    " and r.Ime = :tip");

                q.SetParameter(0, 1990);
                q.SetParameter("tip", "Marko");
                
                IList<Radnik> radnici = q.List<Radnik>();

                foreach (Radnik r in radnici)
                {
                    MessageBox.Show(r.Adresa);
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajDeonicu_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s1 = DataLayer.GetSession();

                Deonica o = s1.Load<Deonica>(5);

                o.Grad2 = "Prokuplje";
                Gradiliste g = s1.Load<Gradiliste>(1);
                o.Gradiliste = g;

                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajSpoljnog_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s1 = DataLayer.GetSession();

                SpoljniSaradnik o = s1.Load<SpoljniSaradnik>(6);

                o.BrojUgovora = 1234;


                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajUpravlja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s1 = DataLayer.GetSession();

                Upravlja o = s1.Load<Upravlja>(1);

                o.Pocetak = DateTime.Parse("03-MAY-2017");
                Vozilo v = s1.Load<Vozilo>(24);
                o.Vozilo = v;

                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdAzurirajGradiliste_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s1 = DataLayer.GetSession();

                Gradiliste o = s1.Load<Gradiliste>(9);

                o.TipGradilista = "MOST";

                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdPrikaziGradiliste_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Gradiliste o = s.Load<Gradiliste>(1);

                foreach (Entiteti.Deonica d in o.Deonice)
                    MessageBox.Show(d.Grad2);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
