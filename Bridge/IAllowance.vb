Public Interface IAllowance

    Property allowanceNum() As UInteger

    Property empNum() As UInteger

    Property allowTypeCode() As UInt16

    Property amount() As Double

    Property remark() As String

    Property taxable() As Boolean

    Property dateCreated() As Date

    Property lastModifiedBy() As UInteger

    Property lastModified() As Date

    Property specify() As String
End Interface
