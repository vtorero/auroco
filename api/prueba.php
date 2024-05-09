<?php


$url = 'ord_medios.xml';
//$xmlc = file_get_contents($url);
$xml = simplexml_load_file($url);


//movimiento saldos
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_MOVIMIENTO_SALDOS` (`C_CONTRATO`, `N_MOVIMIENTO`, `OPERACION`, `C_MONEDA`, `MONTO_MOV`, `SALDO_ACTUAL`, `C_ORDEN`, `OBSERVACIONES`, `F_CREACION`, `C_USUARIO`) VALUES";
//ordenes
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_ORDENES` (`C_ORDEN`, `C_CONTRATO`, `C_CLIENTE`, `C_EJECUTIVO`, `PRODUCTO`, `MOTIVO`, `DURACION`, `INICIO_VIGENCIA`, `FIN_VIGENCIA`, `C_MONEDA`, `INVERSION`, `OBSERVACIONES`, `F_CREACION`, `C_USUARIO`,`C_MEDIO`,`IGV`,`REVISION`,`TIPO`,`ACTIVA`) VALUES ";
//ordenes lineas
//$cadena="INSERT INTO `aprendea_auroco`.`ORDEN_LINEAS` (`C_ORDEN`, `FECHA`,`PROGRAMA`,`GENERO`,`SDIAS`,`RATING`,`MILES`,`INVERSION_TOTAL`,`OBSERVACIONES`,`C_USUARIO`,`CORRELATIVO`,`REVISION`,`PERIODO`) VALUES ";
//CONTRATOS
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_CONTRATOS` (`C_CONTRATO`,`C_CLIENTE`,`INICIO_VIGENCIA`,`FIN_VIGENCIA`,`NRO_FISICO`,`C_MONEDA`,`INVERSION`,`INVER_IGV`,`MONTO_ORDENAR`,`MONTO_ORD_IGV`,`TIPO_CAMBIO`,`TASA_IGV`,`OBSERVACIONES`,`C_USUARIO`,`F_CREACION`) VALUES";
//medios
$cadena="INSERT INTO `aprendea_auroco`.`ORD_MEDIOS` ( `C_MEDIO`, `TIPO`, `NOMBRE`,`DESCRIPCION`,`F_CREACION`,`C_USUARIO_CREACION`) VALUES";
//programas
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_PROGRAMAS_AUT` (`ID`, `PROGRAMA`, `REGION`,`CANAL`,`GENERO`,`TEMA`,`PERIODO`,`DIAS`,`RATING`,`MILES`,`COSTO`,`F_CREACION`,`C_USUARIO`) VALUES";
//contratos
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_CONTRATOS` (`C_CONTRATO`,`C_CLIENTE`,`INICIO_VIGENCIA`,`FIN_VIGENCIA`,`NRO_FISICO`,`C_MONEDA`,`INVERSION`,`INVER_IGV`,`MONTO_ORDENAR`,`MONTO_ORD_IGV`,`TIPO_CAMBIO`,`TASA_IGV`,`OBSERVACIONES`,`C_USUARIO`,`F_CREACION`) VALUES";










    foreach ($xml->ROW as $dato) {

        $arraymeses=array('ENE','FEB','MAR','APR','ABR','MAY','JUN','JUL','AGO','SEP','OCT','NOV','DIC');
        $arraynros=array('01','02','03','04','04','05','06','07','08','09','10','11','12');
        $fecha=str_replace($arraymeses,$arraynros,$dato->F_CREACION);
  //ejecutivos
        //$cadena.=" ('{$ejecutivo->C_EJECUTIVO}','{$ejecutivo->DNI_EJECUTIVO}','{$ejecutivo->NOMBRES}','{$ejecutivo->F_CREACION}','{$ejecutivo->USUARIO}') , ";

        //$dire = iconv('UTF-8', 'ISO-8859-1//TRANSLIT', $dato->DIRECCION);
        //clientes
      //  $cadena.="('{$dato->C_CLIENTE }','{$dato->RAZON_SOCIAL }','{$dato->CONTACTO}','{$dato->RPT_LEGAL}','{$dato->RPT_DNI}','{$dato->RPT_DIRECCION}','{$dato->RUC}','{$dato->DIRECCION}','{$dato->TELEFONO}','{$dato->F_CREACION }','{$dato->USUARIO }') , ";
//medios
$cadena.="('{$dato->C_MEDIO }','{$dato->TIPO }','{$dato->NOMBRE}','{$dato->DESCRIPCION}',DATE_FORMAT('{$fecha}','%d/%m/%y'),'{$dato->C_USUARIO_CREACION}'),";
//programas
//$cadena.="('{$dato->ID_PROGRAMA }','{$dato->PROGRAMA }','{$dato->REGION }','{$dato->CANAL}','{$dato->GENERO}','{$dato->TEMA}','{$dato->PERIODO}','{$dato->DIAS}','{$dato->RATING}','{$dato->MILES}','{$dato->COSTO}','{$dato->F_CREACION}','{$dato->C_USUARIO}') ,";
//contratos
//$cadena.="('{$dato->C_CONTRATO }','{$dato->C_CLIENTE }','{$dato->INICIO_VIGENCIA }','{$dato->FIN_VIGENCIA}','{$dato->NRO_FISICO}','{$dato->C_MONEDA}',{$dato->INVERSION},{$dato->INVER_IGV},{$dato->MONTO_ORDENAR},{$dato->MONTO_OR_IGV},0{$dato->TIPO_CAMBIO},{$dato->TAZA_IGV},'{$dato->OBSERVACIONES}','{$dato->C_USUARIO}','{$dato->F_CREACION}'),";
//movimiento saldos
//$cadena.="('{$dato->C_CONTRATO }',{$dato->N_MOVIMIENTO },'{$dato->OPERACION }','{$dato->C_MONEDA}',{$dato->MONTO_MOV},{$dato->SALDO_ACTUAL},'{$dato->C_ORDEN}','{$dato->OBSERVACIONES}','{$dato->F_CREACION}','{$dato->C_USUARIO}'),";
//ordenes
//$producto=htmlspecialchars($dato->PRODUCTO);
if($dato->INVERSION==""){
    $dato->INVERSION=0;
}
if($dato->C_MONEDA==""){
    $dato->C_MONEDA="-";
}
if($dato->ACTIVA==""){
    $dato->ACTIVA="SI";
}


//ordenes

//$cadena.="(\"{$dato->C_ORDEN }\",\"{$dato->C_CONTRATO }\",\"{$dato->C_CLIENTE }\",\"{$dato->C_EJECUTIVO}\",\"{$dato->PRODUCTO}\",\" {$dato->MOTIVO}\",'{$dato->DURACION}',\"{$dato->INICIO_VIGENCIA}\",\"{$dato->FIN_VIGENCIA}\",\"{$dato->C_MONEDA}\",{$dato->INVERSION},\"{$dato->OBSERVACIONES}\"
//,\"{$dato->F_CREACION}\",\"{$dato->C_USUARIO}\",\"{$dato->C_MEDIO}\",\"{$dato->IGV}\",{$dato->REVISION},\"{$dato->TIPO}\",\"{$dato->ACTIVA}\"),";
//ordenes lineas

//$cadena.="('{$dato->C_ORDEN}','{$dato->FECHA}','{$dato->PROGRAMA}','{$dato->GENERO}','{$dato->SDIAS}','{$dato->RATING}','{$dato->MILES}',{$dato->INVERSION_TOTAL},'{$dato->OBSERVACIONES}','{$dato->C_USUARIO}',{$dato->CORRELATIVO},{$dato->REVISION},'{$dato->PERIODO}'),";
    }


    echo $cadena;

