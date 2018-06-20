--Problem - 20 - Vendor Preference
WITH CTE_TotalPartsPerMechanic(Mechanic,TotalParts)
AS
(
	SELECT m.FirstName+' '+m.LastName AS Mechanic,
	   SUM(op.Quantity)
	FROM Mechanics m
	  JOIN Jobs j
	  ON j.MechanicId=m.MechanicId
	  JOIN Orders o
	  ON o.JobId=j.JobId
	  JOIN OrderParts op
	  ON op.OrderId=o.OrderId
	  JOIN Parts p
	  ON p.PartId=op.PartId
	  JOIN Vendors v
	  ON v.VendorId=p.VendorId
	GROUP BY m.FirstName+' '+m.LastName
)

SELECT tpm.Mechanic,
       pv.Vendor,
	   pv.Ordered,
	   CONCAT(CONVERT(INT,(CONVERT(float,pv.Ordered)/CONVERT(float,tpm.TotalParts))*100),'%') AS Preference
FROM
(
	SELECT m.FirstName+' '+m.LastName AS Mechanic,
		   v.Name AS Vendor,
		   SUM(op.Quantity) AS [Ordered]
	FROM Mechanics m
	  JOIN Jobs j
	  ON j.MechanicId=m.MechanicId
	  JOIN Orders o
	  ON o.JobId=j.JobId
	  JOIN OrderParts op
	  ON op.OrderId=o.OrderId
	  JOIN Parts p
	  ON p.PartId=op.PartId
	  JOIN Vendors v
	  ON v.VendorId=p.VendorId
	GROUP BY m.MechanicId,m.FirstName+' '+m.LastName,v.Name
) AS pv
JOIN CTE_TotalPartsPerMechanic tpm
ON tpm.Mechanic=pv.Mechanic
ORDER BY Mechanic, Ordered DESC, Vendor