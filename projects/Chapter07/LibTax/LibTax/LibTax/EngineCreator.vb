Imports System

Namespace LibTax
    Public Class EngineCreator
        ' Methods
        Public Shared Function CreateCanadianTaxEngine() As ITaxEngine
            Return New LibTax.Canada.TaxEngine()
        End Function

        Public Shared Function CreateWiggleWiggleEngine() As ITaxEngine
            Return New LibTax.WiggleWiggle.TaxEngine()
        End Function

    End Class
End Namespace

