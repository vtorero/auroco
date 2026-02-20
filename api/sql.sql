SELECT concat(f.serie,f.correlativo) C_,c.c_contrato,agencia,t.ruc RUC,t.RAZON_SOCIAL,f.fecha as F_CREACION,c.C_MONEDA,c.inversion,f.total,f.estado,f.mensaje FROM facturas f,ORD_CONTRATOS c,ORD_CLIENTES t  
where CONCAT('T0',f.c_contrato)=c.C_CONTRATO
and c.C_CLIENTE=t.C_CLIENTE;