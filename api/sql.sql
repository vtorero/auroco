SELECT concat(f.serie,f.correlativo) factura,c.c_contrato,agencia,t.ruc,t.RAZON_SOCIAL,f.fecha as F_CREACION,c.C_MONEDA,c.inversion,f.total FROM facturas f,ORD_CONTRATOS c,ORD_CLIENTES t  
where CONCAT('T0',f.c_contrato)=c.C_CONTRATO
and c.C_CLIENTE=t.C_CLIENTE;