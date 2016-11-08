CREATE TABLE class_INVOICE(
	InvoiceNumber	Int			NOT NULL IDENTITY(1,1),
	InvoiceDate		Datetime2	NOT NULL,
	SubTotal		Float		NOT NULL,
	TaxPct			Int			NOT NULL,
	Total			Float		NOT NULL,
	CONSTRAINT		INVOICE_PK	Primary Key(InvoiceNumber)
);

CREATE TABLE class_PRODUCT(
	ProductNumber	Int			NOT NULL IDENTITY(1,1),
	ProductType		NVarChar	NOT NULL,
	ProductDescription	Text	NOT NULL,
	UnitPrice		Float		NOT NULL,

	CONSTRAINT		PRODUCT_PK	Primary Key(ProductNumber)
);

CREATE TABLE class_LINE_ITEM(
	InvoiceNumber	Int			NOT NULL,
	LineNumber		Int			NOT NULL IDENTITY(1,1),
	ProductNumber	Int			NOT NULL,
	Quantity		Int			NOT NULL,
	Unitprice		Float		NOT NULL,
	Total			Float		NOT NULL,
	CONSTRAINT		LINEITEM_PK	Primary Key(InvoiceNumber, LineNumber),
	CONSTRAINT		LITEM_INVOICE_FK	Foreign Key(InvoiceNumber)
					REFERENCES class_INVOICE(InvoiceNumber),
	CONSTRAINT		LITEM_PROD_FK	Foreign Key(ProductNumber)
					REFERENCES class_PRODUCT(ProductNumber),
);
