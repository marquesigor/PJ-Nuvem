USE [PJNuvem]
GO

/****** Object:  StoredProcedure [dbo].[RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual]    Script Date: 28/10/2018 23:36:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RetornaVarasQueTenhamAsCompetenciasDaClasseProcessual] @ClasseProcessualId uniqueidentifier, @ComarcaId uniqueidentifier
AS
SELECT	VaraCompetencia.VaraId As Id
		, Somador.Soma As QuantidadeProcessos
		, ClasseProcessualCompetencias.ClasseProcessualId
FROM	VaraCompetencia

		INNER JOIN Vara
		ON		   Vara.Id = VaraCompetencia.VaraId

		INNER JOIN Competencia
		ON		   Competencia.Id = VaraCompetencia.CompetenciaId

CROSS APPLY(SELECT ClasseProcessualCompetencia.CompetenciaId
                   , ClasseProcessualId
			FROM   ClasseProcessualCompetencia
			WHERE  ClasseProcessualId = @ClasseProcessualId
			) As ClasseProcessualCompetencias

CROSS APPLY(SELECT SUM(QuantidadeProcessos) As Soma
			FROM   VaraCompetencia As VaraCompetenciaSoma
			WHERE  Vara.Id = VaraCompetenciaSoma.VaraId

			Group By VaraCompetenciaSoma.VaraId
			) As Somador

WHERE	VaraCompetencia.CompetenciaId in(ClasseProcessualCompetencias.CompetenciaId)
AND	    ComarcaId = @ComarcaId


