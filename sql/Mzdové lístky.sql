SELECT     Doklady.a16763u10 AS VZ, VyrobniZakazky.a108609u11780 AS RFID, Akce.a12382u10 AS MzdovyListek, Akce.a1035708u10 AS KodOperace, Akce.a424055u10 AS Mnozstvi, VyrobniDokumentace.a402202u10 AS KodSestavy, Akce.a385054u10 AS CasCelkem,
			Statky.a624857u10 * a624859u10 * a624861u10 AS PocetKusuVboxu
FROM        dbo.a378357u10 AS Hlavni INNER JOIN
                  dbo.a290054u10 AS Operace ON Operace.ic = Hlavni.ic_b AND Operace.u = Hlavni.u INNER JOIN
                  dbo.a4222u10 AS Akce ON Akce.ic = Operace.ic AND Akce.u = Operace.u INNER JOIN
                  dbo.a1611959u10 AS PotrebneStatky ON PotrebneStatky.ic_a = Operace.ic AND PotrebneStatky.u_a = Operace.u LEFT OUTER JOIN
                  dbo.a195739u10 AS Technologie ON Technologie.ic = PotrebneStatky.ic_b AND Technologie.u = PotrebneStatky.u_b LEFT OUTER JOIN
                  dbo.a4434u10 AS CleneniAkce ON CleneniAkce.ic_b = Operace.ic AND CleneniAkce.u_b = Operace.u LEFT OUTER JOIN
                  dbo.a337020u10 AS Sestavy ON Sestavy.ic = CleneniAkce.ic_a AND Sestavy.u = CleneniAkce.u_a INNER JOIN
				  --a
				  dbo.a402190u10 AS PolozkaPlanu ON PolozkaPlanu.ic_a = Sestavy.ic AND PolozkaPlanu.u_a = Sestavy.u LEFT OUTER JOIN
				  dbo.a133u0 AS Produkt ON Produkt.ic = PolozkaPlanu.ic_b AND Produkt.ic = PolozkaPlanu.ic_b INNER JOIN
                  dbo.a3460u10 AS Ciselnik ON Ciselnik.ic = Produkt.ic AND Ciselnik.u = Produkt.u INNER JOIN
				  dbo.a131u0 AS Statky ON Ciselnik.ic = Statky.ic AND Ciselnik.u = Statky.u INNER JOIN
				  --a
                  dbo.a402153u10 AS VyrobniDokumentace ON Sestavy.ic = VyrobniDokumentace.ic AND Sestavy.u = VyrobniDokumentace.u INNER JOIN
                  dbo.a343403u10 AS Prislusnost ON Prislusnost.ic_b = Sestavy.ic AND Prislusnost.u_b = Sestavy.u INNER JOIN
                  dbo.a289650u10 AS PolozkyZakazek ON PolozkyZakazek.ic = Prislusnost.ic_a AND PolozkyZakazek.u = Prislusnost.u_a INNER JOIN
                  dbo.a80961u10 AS PolozkyDokladu ON PolozkyDokladu.ic_b = PolozkyZakazek.ic AND PolozkyDokladu.u_b = PolozkyZakazek.u INNER JOIN
                  dbo.a289647u10 AS VyrobniZakazky ON VyrobniZakazky.ic = PolozkyDokladu.ic_a AND VyrobniZakazky.u = PolozkyDokladu.u_a INNER JOIN
                  dbo.a3804u10 AS Doklady ON PolozkyDokladu.ic_a = Doklady.ic AND PolozkyDokladu.u_a = Doklady.u
WHERE     (Technologie.a108429u11780 = 1) AND (VyrobniZakazky.a290227u10 = 2 OR
                  VyrobniZakazky.a290227u10 = 3) AND (Akce.a886326u10 <> 4 AND Akce.a886326u10 <> 6 OR
                  Akce.a886326u10 IS NULL)