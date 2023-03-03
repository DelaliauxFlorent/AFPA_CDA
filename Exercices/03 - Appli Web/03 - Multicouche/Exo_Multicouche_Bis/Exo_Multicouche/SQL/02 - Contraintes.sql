USE exo_MC;

ALTER TABLE Votes ADD CONSTRAINT FK_Votes_CodesValide FOREIGN KEY (idCodeValide) REFERENCES CodesValides(idCodeValide);