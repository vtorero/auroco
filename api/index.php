<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
header('Access-Control-Allow-Origin:*');
header("Access-Control-Allow-Headers: X-API-KEY, Origin, X-Requested-With, Content-Type, Accept, Access-Control-Request-Method");
header("Access-Control-Allow-Methods: GET, POST, OPTIONS, PUT, DELETE");
header("Allow: GET, POST, OPTIONS, PUT, DELETE");

$method = $_SERVER['REQUEST_METHOD'];
if($method == "OPTIONS") {
    die();
}

require_once 'vendor/autoload.php';
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;



$db = new mysqli("localhost","aprendea_auroco","auroco2023","aprendea_auroco");
mysqli_report(MYSQLI_REPORT_ERROR | MYSQLI_REPORT_STRICT);
mysqli_set_charset($db, 'utf8');

if (mysqli_connect_errno()) {
    printf("Conexiónes fallida: %s\n", mysqli_connect_error());
    exit();
}


$app = new Slim\Slim();


$app->get("/ejecutivos",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM ORD_EJECUTIVOS ORDER BY F_CREACION DESC LIMIT 30");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $cliente[]=$fila;
   }
   if(count($cliente)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$cliente);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($cliente);

});

$app->post("/ejecutivo",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json,false);

   try {

    $sql="call P_EJECUTIVO('{$data->DNI_EJECUTIVO}','{$data->NOMBRES}','{$data->USUARIO}')";
   $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);
   $result = array("status"=>true,"message"=>"Ejecutivo registrado correctamente");
   }
   catch(PDOException $e) {
    $result = array("STATUS"=>false,"message"=>$e->getMessage());
   }

    echo  json_encode($result);

});


    $app->put("/ejecutivo",function() use($db,$app){
        $json = $app->request->getBody();
       $data = json_decode($json,false);

       try {
        $sql="call P_EJECUTIVO_UPD('{$data->C_EJECUTIVO}','{$data->DNI_EJECUTIVO}','{$data->NOMBRES}','{$data->USUARIO}')";

       $stmt = mysqli_prepare($db,$sql);
        mysqli_stmt_execute($stmt);
       $result = array("status"=>true,"message"=>"Ejecutivo registrado correctamente");
       }
       catch(PDOException $e) {
        $result = array("STATUS"=>false,"message"=>$e->getMessage());
       }

        echo  json_encode($result);

    });

$app->get("/medios",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM ORD_MEDIOS ORDER BY F_CREACION DESC LIMIT 30");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $cliente[]=$fila;
   }
   if(count($cliente)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$cliente);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($cliente);

});

$app->get("/programas",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM ORD_PROGRAMAS_AUT ORDER BY F_CREACION DESC LIMIT 30");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $cliente[]=$fila;
   }
   if(count($cliente)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$cliente);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($cliente);

});

$app->put("/programa",function() use($db,$app){
    $json = $app->request->getBody();
    $data = json_decode($json,false);
    try {

        $sql="call P_PROGRAMA_UPD('{$data->ID}','{$data->PROGRAMA}','{$data->CANAL}','{$data->PERIODO}','{$data->DIAS}',{$data->COSTO},'{$data->ESTADO}','{$data->C_USUARIO}')";




      $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);

    $result = array("status"=>true,"message"=>"Programa actualizado correctamente");
    }
    catch(PDOException $e) {

        $result = array("status"=>false,"message"=>"Ocurrio un error");
    }

    echo  json_encode($result);
});

$app->post("/programa",function() use($db,$app){
    $json = $app->request->getBody();
    $data = json_decode($json,false);
    try {

        $sql="call P_PROGRAMA('{$data->PROGRAMA}','{$data->CANAL}','{$data->PERIODO}','{$data->DIAS}',{$data->COSTO},'{$data->ESTADO}','{$data->C_USUARIO}')";


      $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);

    $result = array("status"=>true,"message"=>"Programa registrado correctamente");
    }
    catch(PDOException $e) {

        $result = array("status"=>false,"message"=>"Ocurrio un error");
    }

    echo  json_encode($result);
});


$app->get("/contratos",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT co.id,co.C_CONTRATO,cl.C_CLIENTE,cl.RAZON_SOCIAL,INICIO_VIGENCIA,FIN_VIGENCIA,(SELECT SALDO_ACTUAL FROM ORD_MOVIMIENTO_SALDOS WHERE C_CONTRATO=co.C_CONTRATO ORDER BY N_MOVIMIENTO DESC LIMIT 1) as SALDO,NRO_FISICO,C_MONEDA,FORMAT(INVERSION,2) INVERSION,FORMAT(MONTO_ORDENAR,2) MONTO_ORDENAR,TIPO_CAMBIO,OBSERVACIONES,C_USUARIO,co.F_CREACION  FROM ORD_CONTRATOS co, ORD_CLIENTES cl where co.C_CLIENTE=cl.C_CLIENTE order by INICIO_VIGENCIA DESC limit 50");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});

$app->post("/buscaclientes",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);

   $resultado = $db->query("SELECT *  FROM ORD_CLIENTES WHERE RAZON_SOCIAL LIKE '%{$data->RAZON_SOCIAL}%'  order by RAZON_SOCIAL ASC");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});

$app->post("/buscaejecutivos",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);

   $resultado = $db->query("SELECT *  FROM ORD_EJECUTIVOS WHERE NOMBRES LIKE '%{$data->NOMBRES}%'  order by NOMBRES ASC");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});

$app->post("/buscaprograma",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);

   $resultado = $db->query("SELECT *  FROM ORD_PROGRAMAS_AUT WHERE PROGRAMA LIKE '%{$data->PROGRAMA}%'  order by PROGRAMA ASC");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});

$app->post("/buscamedio",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);

   $resultado = $db->query("SELECT *  FROM ORD_MEDIOS WHERE NOMBRE LIKE '%{$data->NOMBRE}%'  order by NOMBRE ASC");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});

$app->post("/buscacontratos",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);

   $resultado = $db->query("SELECT co.id,co.C_CONTRATO,cl.C_CLIENTE,cl.RAZON_SOCIAL,INICIO_VIGENCIA,FIN_VIGENCIA,(SELECT SALDO_ACTUAL FROM ORD_MOVIMIENTO_SALDOS WHERE C_CONTRATO=co.C_CONTRATO ORDER BY N_MOVIMIENTO DESC LIMIT 1) as SALDO,NRO_FISICO,C_MONEDA,FORMAT(INVERSION,2) INVERSION,FORMAT(MONTO_ORDENAR,2) MONTO_ORDENAR,TIPO_CAMBIO,OBSERVACIONES,C_USUARIO,co.F_CREACION  FROM ORD_CONTRATOS co, ORD_CLIENTES cl where co.C_CLIENTE=cl.C_CLIENTE
   AND RAZON_SOCIAL LIKE '%{$data->RAZON_SOCIAL}%'
   order by INICIO_VIGENCIA DESC");
   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});


$app->get("/monedas",function() use($db,$app){
    $resultado = $db->query("SELECT * FROM aprendea_auroco.MONEDAS order by idMONEDAS desc");
   $monedas=array();
   while ($fila = $resultado->fetch_object()) {
   $monedas[]=$fila;
   }

   echo  json_encode($monedas);

    });

    $app->put("/contrato",function() use($db,$app){
        $json = $app->request->getBody();
        $data = json_decode($json,false);
        try {

            $sql="call P_CONTRATO_UPD('{$data->ID}','{$data->C_CLIENTE}','{$data->INICIO_VIGENCIA}','{$data->FIN_VIGENCIA}','{$data->NRO_FISICO}','{$data->C_MONEDA}',{$data->INVERSION},{$data->MONTO_ORDENAR},{$data->TIPO_CAMBIO},'{$data->OBSERVACIONES}','{$data->C_USUARIO}')";

          $stmt = mysqli_prepare($db,$sql);
            mysqli_stmt_execute($stmt);

            $result = array("status"=>true,"message"=>"Contrato nro:{$data->ID} actualizado correctamente");
        }
        catch(PDOException $e) {

            $result = array("status"=>false,"message"=>"Ocurrio un error");
        }
        echo  json_encode($result);
    });

    $app->post("/medio",function() use($db,$app){
        $json = $app->request->getBody();
       $data = json_decode($json,false);

       try {

        $sql="call P_MEDIO('{$data->NOMBRE}','{$data->DESCRIPCION}','{$data->TIPO}','{$data->C_USUARIO_CREACION}')";
       $stmt = mysqli_prepare($db,$sql);
        mysqli_stmt_execute($stmt);
       $result = array("status"=>true,"message"=>"Medio registrado correctamente");
       }
       catch(PDOException $e) {
        $result = array("STATUS"=>false,"message"=>$e->getMessage());
       }

        echo  json_encode($result);

    });

    $app->put("/medio",function() use($db,$app){
        $json = $app->request->getBody();
        $data = json_decode($json,false);
        try {

            $sql="call P_MEDIO_UPD('{$data->C_MEDIO}','{$data->NOMBRE}','{$data->DESCRIPCION}','{$data->TIPO}','{$data->C_USUARIO_CREACION}')";


          $stmt = mysqli_prepare($db,$sql);
        mysqli_stmt_execute($stmt);

        $result = array("status"=>true,"message"=>"Medio actualizado correctamente");
        }
        catch(PDOException $e) {

            $result = array("status"=>false,"message"=>"Ocurrio un error");
        }

        echo  json_encode($result);
    });

    $app->post("/cliente",function() use($db,$app){
        $json = $app->request->getBody();
       $data = json_decode($json,false);

       try {

        $sql="call P_CLIENTE('{$data->RAZON_SOCIAL}','{$data->RUC}','{$data->DIRECCION}','{$data->TELEFONO}','{$data->CONTACTO}','{$data->RPT_LEGAL}','{$data->RPT_DNI}','{$data->RPT_DIRECCION}','{$data->USUARIO_CREACION}')";



       $stmt = mysqli_prepare($db,$sql);
        mysqli_stmt_execute($stmt);

       $result = array("status"=>true,"message"=>"Cliente registrado correctamente");

       }
       catch(PDOException $e) {
        $result = array("STATUS"=>false,"message"=>$e->getMessage());
       }

        echo  json_encode($result);

    });



    $app->put("/cliente",function() use($db,$app){
        $json = $app->request->getBody();
        $data = json_decode($json,false);
        try {

            $sql="call P_CLIENTE_UPD('{$data->C_CLIENTE}','{$data->RAZON_SOCIAL}','{$data->RUC}','{$data->DIRECCION}','{$data->TELEFONO}','{$data->CONTACTO}','{$data->RPT_LEGAL}','{$data->RPT_DNI}','{$data->RPT_DIRECCION}','{$data->USUARIO_CREACION}')";


          $stmt = mysqli_prepare($db,$sql);
        mysqli_stmt_execute($stmt);

        $result = array("status"=>true,"message"=>"Cliente actualizado correctamente");
        }
        catch(PDOException $e) {

            $result = array("status"=>false,"message"=>"Ocurrio un error");
        }

        echo  json_encode($result);
    });


$app->post("/contrato",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json,false);


   try {



    $sql="call p_contrato('{$data->C_CLIENTE}','{$data->INICIO_VIGENCIA}','{$data->FIN_VIGENCIA}','{$data->NRO_FISICO}','{$data->C_MONEDA}',{$data->INVERSION},{$data->MONTO_ORDENAR},{$data->TIPO_CAMBIO},'{$data->OBSERVACIONES}','{$data->C_USUARIO}')";


   $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);


    $resultado = $db->query("SELECT @SCODIGO");
    $fila = $resultado->fetch_assoc();


   $result = array("status"=>true,"message"=>"Contrato registrado correctamente con el código:".$fila['@SCODIGO']);

   }
   catch(PDOException $e) {
    $result = array("STATUS"=>false,"message"=>$e->getMessage());
   }

    echo  json_encode($result);

});

$app->post("/buscaorden",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, false);
   $fecha1 = explode("/", $data->INICIO_VIGENCIA);
   $fecha2= explode("/", $data->FIN_VIGENCIA);
   $ano1=explode(" ",$fecha1[2]);
   $ano2=explode(" ",$fecha2[2]);
   $inicio=$ano1[0]."-".$fecha1[1]."-".$fecha1[0];
   $fin=$ano2[0]."-".$fecha2[1]."-".$fecha2[0];

$sql="SELECT O.ID,O.C_ORDEN,O.C_MEDIO,M.NOMBRE,O.C_CLIENTE,C.RAZON_SOCIAL,E.C_EJECUTIVO,E.NOMBRES EJECUTIVO,PRODUCTO,MOTIVO,C_CONTRATO,INICIO_VIGENCIA,O.F_CREACION,FIN_VIGENCIA,O.C_MONEDA,O.PRODUCTO,O.MOTIVO,O.DURACION,O.OBSERVACIONES,O.REVISION,O.ACTIVA,O.AGENCIA,O.INVERSION AS TOTAL FROM ORD_ORDENES O,ORD_CLIENTES C,ORD_MEDIOS M,ORD_EJECUTIVOS E WHERE O.C_CLIENTE=C.C_CLIENTE AND O.C_MEDIO=M.C_MEDIO AND O.C_EJECUTIVO=E.C_EJECUTIVO
AND O.C_CLIENTE='{$data->C_CLIENTE}' ";

if($data->C_MEDIO!="") {

    $sql.=" AND M.C_MEDIO = '{$data->C_MEDIO}' ";

}

if($data->INICIO_VIGENCIA!="" && $data->FIN_VIGENCIA!="") {

    $sql.=" AND O.INICIO_VIGENCIA BETWEEN '{$inicio}' and '{$fin}'";

}
$sql.=" ORDER  by O.F_CREACION DESC";

//print_r($sql);
//die;
   $resultado = $db->query($sql);
   $ordenes=array();

   while ($fila = $resultado->fetch_object()) {
   $ordenes[]=$fila;
   }
   if(count($ordenes)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$ordenes);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($ordenes);

});


$app->post("/login",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM ORD_USUARIOS where usuario='".$data['usuario']."' and password='".$data['password']."'");
   $usuario=array();
   while ($fila = $resultado->fetch_object()) {
   $usuario[]=$fila;
   }
   if(count($usuario)==1){
       $data = array("status"=>true,"rows"=>1,"data"=>$usuario);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($data);
});

$app->get("/parse",function() use($db,$app){
    //ni_set('allow_url_fopen',1);
    $url = 'https://lh-cjm.com/api-auroco/ord_clientes.xml';
//  $xml = file_get_contents($url);
    $xml = simplexml_load_file($url);


//ejecutivos
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_EJECUTIVOS`    (`C_EJECUTIVO`,    `DNI_EJECUTIVO`,    `NOMBRES`,    `F_CREACION`,    `USUARIO`   ) VALUES ";
//clientes
$cadena="INSERT INTO `aprendea_auroco`.`ORD_CLIENTES` ( `C_CLIENTE`, `RAZON_SOCIAL`, `CONTACTO`, `RPT_LEGAL`, `RPT_DNI`, `RPT_DIRECCION`, `RUC`, `DIRECCION`, `TELEFONO`, `F_CREACION`, `USUARIO`) VALUES ";
//medios
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_MEDIOS` (`ID`, `C_MEDIO`, `TIPO`, `NOMBRE`,`DESCRIPCION`,`F_CREACION`,`C_USUARIO_CREACION`) VALUES";
//programas
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_PROGRAMAS_AUT` (`ID`, `PROGRAMA`, `REGION`,`CANAL`,`GENERO`,`TEMA`,`PERIODO`,`DIAS`,`RATING`,`MILES`,`COSTO`,`F_CREACION`,`C_USUARIO`) VALUES";
//contratos
//$cadena="INSERT INTO `aprendea_auroco`.`ORD_CONTRATOS` (`C_CONTRATO`,`C_CLIENTE`,`INICIO_VIGENCIA`,`FIN_VIGENCIA`,`NRO_FISICO`,`C_MONEDA`,`INVERSION`,`INVER_IGV`,`MONTO_ORDENAR`,`MONTO_ORD_IGV`,`TIPO_CAMBIO`,`TASA_IGV`,`OBSERVACIONES`,`C_USUARIO`,`F_CREACION`) VALUES";


    foreach ($xml->ROW as $dato) {

        //ejecutivos
        //$cadena.=" ('{$ejecutivo->C_EJECUTIVO}','{$ejecutivo->DNI_EJECUTIVO}','{$ejecutivo->NOMBRES}','{$ejecutivo->F_CREACION}','{$ejecutivo->USUARIO}') , ";

        //$dire = iconv('UTF-8', 'ISO-8859-1//TRANSLIT', $dato->DIRECCION);
        //clientes
      //  $cadena.="('{$dato->C_CLIENTE }','{$dato->RAZON_SOCIAL }','{$dato->CONTACTO}','{$dato->RPT_LEGAL}','{$dato->RPT_DNI}','{$dato->RPT_DIRECCION}','{$dato->RUC}','{$dato->DIRECCION}','{$dato->TELEFONO}','{$dato->F_CREACION }','{$dato->USUARIO }') , ";
//medios
//$cadena.="('{$dato->C_MEDIO }','{$dato->TIPO }','{$dato->NOMBRE}','{$dato->DESCRIPCION}','{$dato->F_CREACION}','{$dato->C_USUARIO_CREACION}'),";
//programas
//$cadena.="('{$dato->ID_PROGRAMA }','{$dato->PROGRAMA }','{$dato->REGION }','{$dato->CANAL}','{$dato->GENERO}','{$dato->TEMA}','{$dato->PERIODO}','{$dato->DIAS}','{$dato->RATING}','{$dato->MILES}','{$dato->COSTO}','{$dato->F_CREACION}','{$dato->C_USUARIO}') ,";

$cadena.="('{$dato->C_CONTRATO }','{$dato->C_CLIENTE }','{$dato->INICIO_VIGENCIA }','{$dato->FIN_VIGENCIA}','{$dato->NRO_FISICO}','{$dato->C_MONEDA}',{$dato->INVERSION},{$dato->INVER_IGV},{$dato->MONTO_ORDENAR},{$dato->MONTO_OR_IGV},{$dato->TIPO_CAMBIO},{$dato->TASA_IGV},'{$dato->OBSERVACIONES}','{$dato->C_USUARIO}','{$dato->F_CREACION}'),";



    }

echo $cadena;

/*    foreach ($xml  as $tag) {
        print_r($tag);
    }*/
});


$app->post("/contrato",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM ORD_USUARIO where usuario='".$data['usuario']."' and password='".$data['password']."'");
   $usuario=array();
   while ($fila = $resultado->fetch_object()) {
   $usuario[]=$fila;
   }
   if(count($usuario)==1){
       $data = array("status"=>true,"rows"=>1,"data"=>$usuario);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($data);
});

$app->get("/clientes",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM aprendea_auroco.ORD_CLIENTES;");
   $clientes=array();
   $clientes[]=["C_CLIENTE"=>"0","RAZON_SOCIAL"=>"Seleccionar Cliente"];
   while ($fila = $resultado->fetch_object()) {
   $clientes[]=$fila;
   }
   if(count($clientes)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$clientes);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($clientes);

});


$app->get("/clientes_orden",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT CL.C_CLIENTE,RAZON_SOCIAL FROM ORD_CLIENTES CL , ORD_CONTRATOS CO WHERE CL.C_CLIENTE=CO.C_CLIENTE group by C_CLIENTE,RAZON_SOCIAL ORDER  by CL.RAZON_SOCIAL ASC");
   $contrato=array();
   $contrato[]=["C_CLIENTE"=>"0","RAZON_SOCIAL"=>"Seleccionar Cliente"];
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});
$app->get("/ordenprint/:id",function($id) use ($app,$db){
    $json = $app->request->getBody();
    $data = json_decode($json, true);

    $db->query("SET lc_time_names = 'es_ES'");
    $resultado = $db->query("SELECT ORD.ID,ORD.C_ORDEN,ORD.REVISION,ORD.NOMBRE,ORD.MES_VIGENCIA,ORD.INICIO_VIGENCIA,ORD.FIN_VIGENCIA,ORD.C_MONEDA,ORD.RUC,ORD.RAZON_SOCIAL,ORD.PRODUCTO,ORD.MOTIVO,ORD.DURACION,ORD.PROGRAMA,ORD.DIAS,ORD.PERIODO,ORD.TEMA,ORD.C_MEDIO,ORD.INVERSION_TOTAL,ORD.OBSERVACIONES,
    SUM(IF(DAY(ORD.FECHA)=01,XCONT,'')) d1,
     SUM(IF(DAY(ORD.FECHA)=02,XCONT,'')) d2,
     SUM(IF(DAY(ORD.FECHA)=03,XCONT,'')) d3,
     SUM(IF(DAY(ORD.FECHA)=04,XCONT,'')) d4,
     SUM(IF(DAY(ORD.FECHA)=05,XCONT,'')) d5,
     SUM(IF(DAY(ORD.FECHA)=06,XCONT,'')) d6,
     SUM(IF(DAY(ORD.FECHA)=07,XCONT,'')) d7,
     SUM(IF(DAY(ORD.FECHA)=08,XCONT,'')) d8,
     SUM(IF(DAY(ORD.FECHA)=09,XCONT,'')) d9,
     SUM(IF(DAY(ORD.FECHA)=10,XCONT,'')) d10,
     SUM(IF(DAY(ORD.FECHA)=11,XCONT,'')) d11,
     SUM(IF(DAY(ORD.FECHA)=12,XCONT,'')) d12,
     SUM(IF(DAY(ORD.FECHA)=13,XCONT,'')) d13,
     SUM(IF(DAY(ORD.FECHA)=14,XCONT,'')) d14,
     SUM(IF(DAY(ORD.FECHA)=15,XCONT,'')) d15,
     SUM(IF(DAY(ORD.FECHA)=16,XCONT,'')) d16,
     SUM(IF(DAY(ORD.FECHA)=17,XCONT,'')) d17,
     SUM(IF(DAY(ORD.FECHA)=18,XCONT,'')) d18,
     SUM(IF(DAY(ORD.FECHA)=19,XCONT,'')) d19,
     SUM(IF(DAY(ORD.FECHA)=20,XCONT,'')) d20,
     SUM(IF(DAY(ORD.FECHA)=21,XCONT,'')) d21,
     SUM(IF(DAY(ORD.FECHA)=22,XCONT,'')) d22,
     SUM(IF(DAY(ORD.FECHA)=23,XCONT,'')) d23,
     SUM(IF(DAY(ORD.FECHA)=24,XCONT,'')) d24,
     SUM(IF(DAY(ORD.FECHA)=25,XCONT,'')) d25,
     SUM(IF(DAY(ORD.FECHA)=26,XCONT,'')) d26,
     SUM(IF(DAY(ORD.FECHA)=27,XCONT,'')) d27,
     SUM(IF(DAY(ORD.FECHA)=28,XCONT,'')) d28,
     SUM(IF(DAY(ORD.FECHA)=29,XCONT,'')) d29,
     SUM(IF(DAY(ORD.FECHA)=30,XCONT,'')) d30,
     SUM(IF(DAY(ORD.FECHA)=31,XCONT,'')) d31,
    SUM(IF(DAY(ORD.FECHA)=01,XCONT,'')+IF(DAY(ORD.FECHA)=02,XCONT,'')
       +IF(DAY(ORD.FECHA)=03,XCONT,'')+IF(DAY(ORD.FECHA)=04,XCONT,'')+IF(DAY(ORD.FECHA)=05,XCONT,'')+IF(DAY(ORD.FECHA)=06,XCONT,'')+IF(DAY(ORD.FECHA)=07,XCONT,'')
    +IF(DAY(ORD.FECHA)=08,XCONT,'')+IF(DAY(ORD.FECHA)=09,XCONT,'')+IF(DAY(ORD.FECHA)=10,XCONT,'')+IF(DAY(ORD.FECHA)=11,XCONT,'')+IF(DAY(ORD.FECHA)=12,XCONT,'')
    +IF(DAY(ORD.FECHA)=13,XCONT,'')+IF(DAY(ORD.FECHA)=14,XCONT,'')+IF(DAY(ORD.FECHA)=15,XCONT,'')+IF(DAY(ORD.FECHA)=16,XCONT,'')+IF(DAY(ORD.FECHA)=17,XCONT,'')
    +IF(DAY(ORD.FECHA)=18,XCONT,'')+IF(DAY(ORD.FECHA)=19,XCONT,'')+IF(DAY(ORD.FECHA)=20,XCONT,'')+IF(DAY(ORD.FECHA)=21,XCONT,'')+IF(DAY(ORD.FECHA)=22,XCONT,'')
    +IF(DAY(ORD.FECHA)=23,XCONT,'')+IF(DAY(ORD.FECHA)=24,XCONT,'')+IF(DAY(ORD.FECHA)=25,XCONT,'')+IF(DAY(ORD.FECHA)=26,XCONT,'')+IF(DAY(ORD.FECHA)=27,XCONT,'')
    +IF(DAY(ORD.FECHA)=28,XCONT,'')+IF(DAY(ORD.FECHA)=29,XCONT,'')+IF(DAY(ORD.FECHA)=30,XCONT,'')+IF(DAY(ORD.FECHA)=31,XCONT,'')) TOTAL_AVISOS
     ,ORD.INVERSION_TOTAL * 	SUM(IF(DAY(ORD.FECHA)=01,XCONT,'')+IF(DAY(ORD.FECHA)=02,XCONT,'')
       +IF(DAY(ORD.FECHA)=03,XCONT,'')+IF(DAY(ORD.FECHA)=04,XCONT,'')+IF(DAY(ORD.FECHA)=05,XCONT,'')+IF(DAY(ORD.FECHA)=06,XCONT,'')+IF(DAY(ORD.FECHA)=07,XCONT,'')
    +IF(DAY(ORD.FECHA)=08,XCONT,'')+IF(DAY(ORD.FECHA)=09,XCONT,'')+IF(DAY(ORD.FECHA)=10,XCONT,'')+IF(DAY(ORD.FECHA)=11,XCONT,'')+IF(DAY(ORD.FECHA)=12,XCONT,'')
    +IF(DAY(ORD.FECHA)=13,XCONT,'')+IF(DAY(ORD.FECHA)=14,XCONT,'')+IF(DAY(ORD.FECHA)=15,XCONT,'')+IF(DAY(ORD.FECHA)=16,XCONT,'')+IF(DAY(ORD.FECHA)=17,XCONT,'')
    +IF(DAY(ORD.FECHA)=18,XCONT,'')+IF(DAY(ORD.FECHA)=19,XCONT,'')+IF(DAY(ORD.FECHA)=20,XCONT,'')+IF(DAY(ORD.FECHA)=21,XCONT,'')+IF(DAY(ORD.FECHA)=22,XCONT,'')
    +IF(DAY(ORD.FECHA)=23,XCONT,'')+IF(DAY(ORD.FECHA)=24,XCONT,'')+IF(DAY(ORD.FECHA)=25,XCONT,'')+IF(DAY(ORD.FECHA)=26,XCONT,'')+IF(DAY(ORD.FECHA)=27,XCONT,'')
    +IF(DAY(ORD.FECHA)=28,XCONT,'')+IF(DAY(ORD.FECHA)=29,XCONT,'')+IF(DAY(ORD.FECHA)=30,XCONT,'')+IF(DAY(ORD.FECHA)=31,XCONT,'')) AS TOTAL_COSTO

   FROM
(select O.C_ORDEN,CL.RUC,CL.RAZON_SOCIAL,O.C_MEDIO,M.NOMBRE,O.OBSERVACIONES,
               monthname(O.INICIO_VIGENCIA)  AS  MES_VIGENCIA,
 			O.INICIO_VIGENCIA,
 O.FIN_VIGENCIA,
              P.ID,
              P.PROGRAMA,
              P.TEMA,
              P.DIAS,
              P.PERIODO,
              sum(l.inversion_total) COSTO,
              O.PRODUCTO,
              O.C_MONEDA,
      O.REVISION,
              O.MOTIVO,
              l.RATING,
              l.MILES,
              O.DURACION,
              l.INVERSION_TOTAL,
              FECHA,
              count(*)  XCONT
         from ORDEN_LINEAS l,
              ORD_ORDENES        O,
              ORD_MEDIOS         M,
              ORD_PROGRAMAS_AUT  P,
              ORD_CONTRATOS      CO,
              ORD_CLIENTES       CL
        where
          CL.C_CLIENTE = CO.C_CLIENTE
          and O.C_MEDIO=M.C_MEDIO
          AND O.C_ORDEN = l.C_ORDEN
         AND l.idPrograma = P.ID
          AND O.C_CONTRATO=CO.C_CONTRATO AND l.C_ORDEN='{$id}'
          group by O.C_ORDEN,
           P.ID,
           CL.RUC,
                 CL.RAZON_SOCIAL,
                 O.C_MEDIO,
                 M.NOMBRE,
                 O.OBSERVACIONES,
              month(O.INICIO_VIGENCIA),
 				O.INICIO_VIGENCIA,
                  O.FIN_VIGENCIA,
                 P.PROGRAMA,
                 P.TEMA,
                 O.REVISION,
                 O.PRODUCTO,
                 O.C_MONEDA,
                 O.MOTIVO,
                 l.RATING,
                 l.MILES,
                 O.DURACION,
                 l.INVERSION_TOTAL,
                 FECHA) ORD
                 GROUP BY ORD.C_ORDEN,
                 ORD.ID,
                   ORD.RAZON_SOCIAL,
       ORD.RUC
       ,
          ORD.C_MEDIO,
      ORD.NOMBRE,
      ORD.OBSERVACIONES,

      ORD.PROGRAMA,
      ORD.TEMA,
      ORD.C_MONEDA,
    ORD.PRODUCTO,
    ORD.MES_VIGENCIA,
    ORD.INICIO_VIGENCIA,
    ORD.FIN_VIGENCIA,
         ORD.MOTIVO,
           ORD.REVISION,
         ORD.RATING,
         ORD.MILES,
         ORD.DURACION,
         ORD.INVERSION_TOTAL;");
    $datos=array();
    while ($fila = $resultado->fetch_object()) {
    $datos[]=$fila;
    }
    echo  json_encode($datos);


});

$app->get("/orden/:id",function($id) use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);
   $resultado = $db->query("SELECT ORD.ID,ORD.TEMA,ORD.C_MEDIO,ORD.INVERSION_TOTAL,SUM(IF(DAY(ORD.FECHA)=01,XCONT,'')) d1,
         SUM(IF(DAY(ORD.FECHA)=02,XCONT,'')) d2,
         SUM(IF(DAY(ORD.FECHA)=03,XCONT,'')) d3,
         SUM(IF(DAY(ORD.FECHA)=04,XCONT,'')) d4,
         SUM(IF(DAY(ORD.FECHA)=05,XCONT,'')) d5,
         SUM(IF(DAY(ORD.FECHA)=06,XCONT,'')) d6,
         SUM(IF(DAY(ORD.FECHA)=07,XCONT,'')) d7,
         SUM(IF(DAY(ORD.FECHA)=08,XCONT,'')) d8,
         SUM(IF(DAY(ORD.FECHA)=09,XCONT,'')) d9,
         SUM(IF(DAY(ORD.FECHA)=10,XCONT,'')) d10,
         SUM(IF(DAY(ORD.FECHA)=11,XCONT,'')) d11,
         SUM(IF(DAY(ORD.FECHA)=12,XCONT,'')) d12,
         SUM(IF(DAY(ORD.FECHA)=13,XCONT,'')) d13,
         SUM(IF(DAY(ORD.FECHA)=14,XCONT,'')) d14,
         SUM(IF(DAY(ORD.FECHA)=15,XCONT,'')) d15,
         SUM(IF(DAY(ORD.FECHA)=16,XCONT,'')) d16,
         SUM(IF(DAY(ORD.FECHA)=17,XCONT,'')) d17,
         SUM(IF(DAY(ORD.FECHA)=18,XCONT,'')) d18,
         SUM(IF(DAY(ORD.FECHA)=19,XCONT,'')) d19,
         SUM(IF(DAY(ORD.FECHA)=20,XCONT,'')) d20,
         SUM(IF(DAY(ORD.FECHA)=21,XCONT,'')) d21,
         SUM(IF(DAY(ORD.FECHA)=22,XCONT,'')) d22,
         SUM(IF(DAY(ORD.FECHA)=23,XCONT,'')) d23,
         SUM(IF(DAY(ORD.FECHA)=24,XCONT,'')) d24,
         SUM(IF(DAY(ORD.FECHA)=25,XCONT,'')) d25,
         SUM(IF(DAY(ORD.FECHA)=26,XCONT,'')) d26,
         SUM(IF(DAY(ORD.FECHA)=27,XCONT,'')) d27,
         SUM(IF(DAY(ORD.FECHA)=28,XCONT,'')) d28,
         SUM(IF(DAY(ORD.FECHA)=29,XCONT,'')) d29,
         SUM(IF(DAY(ORD.FECHA)=30,XCONT,'')) d30,
         SUM(IF(DAY(ORD.FECHA)=31,XCONT,'')) d31
       FROM
   (select O.C_ORDEN,CL.RAZON_SOCIAL,O.C_MEDIO,M.NOMBRE,O.OBSERVACIONES,
                  month(O.INICIO_VIGENCIA)  AS  INICIO_VIGENCIA,
                  P.ID,
                  P.PROGRAMA,
                  P.TEMA,
                  sum(l.inversion_total) COSTO,
                  O.PRODUCTO,
                  O.MOTIVO,
                  l.RATING,
                  l.MILES,
                  O.DURACION,
                  l.INVERSION_TOTAL,
                  FECHA,
                  count(*)  XCONT
             from ORDEN_LINEAS l,
                  ORD_ORDENES        O,
                  ORD_MEDIOS         M,
                  ORD_PROGRAMAS_AUT  P,
                  ORD_CONTRATOS      CO,
                  ORD_CLIENTES       CL
            where
              CL.C_CLIENTE = CO.C_CLIENTE
              and O.C_MEDIO=M.C_MEDIO
              AND O.C_ORDEN = l.C_ORDEN
             AND l.idPrograma = P.ID
              AND O.C_CONTRATO=CO.C_CONTRATO AND l.C_ORDEN='{$id}'
              group by O.C_ORDEN,
               P.ID,
                     CL.RAZON_SOCIAL,
                     O.C_MEDIO,
                     M.NOMBRE,
                     O.OBSERVACIONES,
                     O.INICIO_VIGENCIA,
                     P.PROGRAMA,
                     P.TEMA,
                     O.PRODUCTO,
                     O.MOTIVO,
                     l.RATING,
                     l.MILES,
                     O.DURACION,
                     l.INVERSION_TOTAL,
                     FECHA) ORD
                     GROUP BY ORD.C_ORDEN,
                     ORD.ID,
                       ORD.RAZON_SOCIAL,
           ORD.RAZON_SOCIAL,
              ORD.C_MEDIO,
          ORD.NOMBRE,
          ORD.OBSERVACIONES,
          ORD.INICIO_VIGENCIA,
          ORD.PROGRAMA,
          ORD.TEMA,
        ORD.PRODUCTO,
             ORD.MOTIVO,
             ORD.RATING,
             ORD.MILES,
             ORD.DURACION,
             ORD.INVERSION_TOTAL

             ");
   $datos=array();
   while ($fila = $resultado->fetch_object()) {
   $datos[]=$fila;
   }
  /* if(count($datos)>0){
       $data = array("status"=>true,"rows"=>count($datos),"data"=>$datos);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }*/
   echo  json_encode($datos);

});



$app->get("/ordenes",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT O.ID,O.C_ORDEN,O.C_MEDIO,M.NOMBRE,O.C_CLIENTE,O.REVISION,O.ACTIVA,C.RAZON_SOCIAL,E.C_EJECUTIVO,E.NOMBRES EJECUTIVO,PRODUCTO,MOTIVO,C_CONTRATO,INICIO_VIGENCIA,O.F_CREACION,FIN_VIGENCIA,O.C_MONEDA,O.AGENCIA,O.PRODUCTO,O.MOTIVO,O.DURACION,O.OBSERVACIONES,O.INVERSION AS TOTAL FROM ORD_ORDENES O,ORD_CLIENTES C,ORD_MEDIOS M,ORD_EJECUTIVOS E WHERE O.C_CLIENTE=C.C_CLIENTE AND O.C_MEDIO=M.C_MEDIO AND O.C_EJECUTIVO=E.C_EJECUTIVO AND O.AGENCIA='AUROCO'  ORDER  by O.C_ORDEN DESC limit 50");
   $ordenes=array();

   while ($fila = $resultado->fetch_object()) {
   $ordenes[]=$fila;
   }
   if(count($ordenes)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$ordenes);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($ordenes);

});

$app->put("/orden",function() use ($app,$db){
    $json = $app->request->getBody();
    $data = json_decode($json,false);
    $fecha1 = explode("/", $data->FECHA_INICIO);
    $fecha2= explode("/", $data->FECHA_FIN);
    $ano1=explode(" ",$fecha1[2]);
    $ano2=explode(" ",$fecha2[2]);
    $inicio=$ano1[0]."-".$fecha1[1]."-".$fecha1[0];
    $fin=$ano2[0]."-".$fecha2[1]."-".$fecha2[0];

    try{
    $sql="call SP_UPDATE_ORDENES('{$data->C_ORDEN}','{$data->C_CONTRATO}','{$data->REVISION}','{$data->C_CLIENTE}','{$data->C_MEDIO}','{$data->C_EJECUTIVO}','{$data->PRODUCTO}','{$data->MOTIVO}','{$data->DURACION}','{$inicio}','{$fin}','{$data->IGV}','{$data->C_MONEDA}',{$data->INVERSION},'{$data->OBSERVACIONES}','{$data->C_USUARIO}','{$data->AGENCIA}',@SCODIGO,@PV_MENSAJE_ERROR,@VAL_ERROR)";
    $stmt = mysqli_prepare($db,$sql);
   mysqli_stmt_execute($stmt);

    $resultado = $db->query("SELECT @SCODIGO,@PV_MENSAJE_ERROR,@VAL_ERROR");
    $fila = $resultado->fetch_assoc();


    if($fila['@VAL_ERROR']=='NO'){


        foreach ($data->orden as $i => $item) {

            for ($v=0; $v < (int)$item->d1;$v++) {
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$inicio}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);


            }
            for ($v=0; $v < (int)$item->d2; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 1 days'));

                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);


            }

            for ($v=0; $v < (int)$item->d3; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 2 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);

            }
            for ($v=0; $v < (int)$item->d4; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 3 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);

            }
            for ($v=0; $v < (int)$item->d5; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 4 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);

            }
            for ($v=0; $v < (int)$item->d6; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 5 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d7; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 6 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }
            for ($v=0; $v < (int)$item->d8; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 7 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d9; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 8 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

                $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d10; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 9 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }
            for ($v=0; $v < (int)$item->d11; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 10 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d12; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 11 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }
            for ($v=0; $v < (int)$item->d13; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 12 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d14; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 13 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d15; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 14 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d16; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 15 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d17; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 16 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d18; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 17 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d19; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 18 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d20; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 19 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d21; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 20 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d22; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 21 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d23; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 22 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d24; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 23 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d25; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 24 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d26; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 25 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d27; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 26 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d28; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 27 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d29; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 28 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d30; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 29 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

            for ($v=0; $v < (int)$item->d31; $v++) {
                $fec=date('Y-m-d', strtotime($inicio. ' + 30 days'));
                $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
               $stmt = mysqli_prepare($db,$sql2);
                mysqli_stmt_execute($stmt);
            }

          }


          $resultado = $db->query("SELECT @VALOR_ERROR");

          $fila2 = $resultado->fetch_assoc();
        if($fila2['@VALOR_ERROR']=='NO' || $fila2['@VALOR_ERROR']==NULL){

          //$result = array("status"=>true,"message"=>"Orden creada correctamente con el nro:".$fila['@SCODIGO'],"data"=>$data,"error"=>$error);
          $result = array("status"=>true,"message"=>"Orden creada correctamente con el nro:".$fila['@SCODIGO']);

        }
        else{
            $result = array("status"=>false,"message"=>$fila['@VALOR_ERROR']);
        }
        }else{
            //$result = array("status"=>false,"message"=>$fila['@PV_MENSAJE_ERROR'],"data"=>$data);
            $result = array("status"=>false);
    }




    $result = array("status"=>true,"message"=>"Orden actualizada correctamente :".$data->C_ORDEN);

}
catch(PDOException $e) {

    $result = array("status"=>false,"message"=>"Ocurrio un error");
}


echo  json_encode($result);








});

$app->get("/anulaorden/:id",function($id) use ($app,$db){
    $json = $app->request->getBody();
    $data = json_decode($json, true);
    try{
    $sql="call SP_ANULAR_ORDENES('{$id}',@PV_MENSAJE_ERROR,@VAL_ERROR);";
    $stmt = mysqli_prepare($db,$sql);
   mysqli_stmt_execute($stmt);

   $result = array("status"=>true,"message"=>"Orden anulada correctamente :".$id);


    }
    catch(PDOException $e) {

        $result = array("status"=>false,"message"=>"Ocurrio un error");

    }

    echo  json_encode($result);

});

$app->post("/orden",function() use ($app,$db){
    $json = $app->request->getBody();
    $data = json_decode($json,false);
    $fecha1 = explode("/", $data->FECHA_INICIO);
    $fecha2= explode("/", $data->FECHA_FIN);
    $ano1=explode(" ",$fecha1[2]);
    $ano2=explode(" ",$fecha2[2]);
    $inicio=$ano1[0]."-".$fecha1[1]."-".$fecha1[0];
    $fin=$ano2[0]."-".$fecha2[1]."-".$fecha2[0];

try{
//'
    $sql="call SP_GRABA_ORDENES('{$data->C_CONTRATO}','{$data->C_CLIENTE}','{$data->C_MEDIO}','{$data->C_EJECUTIVO}','{$data->PRODUCTO}','{$data->MOTIVO}','{$data->DURACION}','{$inicio}','{$fin}','{$data->IGV}','{$data->C_MONEDA}',{$data->INVERSION},'{$data->OBSERVACIONES}','{$data->C_USUARIO}','{$data->AGENCIA}',@SCODIGO,@PV_MENSAJE_ERROR,@VAL_ERROR)";




    $stmt = mysqli_prepare($db,$sql);
   mysqli_stmt_execute($stmt);
   /* cerrar la sentencia */
   // mysqli_stmt_close($stmt);


    $resultado = $db->query("SELECT @SCODIGO,@PV_MENSAJE_ERROR,@VAL_ERROR");
    $fila = $resultado->fetch_assoc();



    if($fila['@VAL_ERROR']=='NO'){


    foreach ($data->orden as $i => $item) {

        for ($v=0; $v < (int)$item->d1;$v++) {
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$inicio}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);


        }
        for ($v=0; $v < (int)$item->d2; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 1 days'));

            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);


        }

        for ($v=0; $v < (int)$item->d3; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 2 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);

        }
        for ($v=0; $v < (int)$item->d4; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 3 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);

        }
        for ($v=0; $v < (int)$item->d5; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 4 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);

        }
        for ($v=0; $v < (int)$item->d6; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 5 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d7; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 6 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d8; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 7 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d9; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 8 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d10; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 9 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d11; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 10 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d12; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 11 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d13; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 12 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d14; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 13 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d15; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 14 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d16; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 15 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d17; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 16 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d18; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 17 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d19; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 18 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d20; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 19 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d21; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 20 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d22; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 21 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d23; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 22 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d24; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 23 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d25; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 24 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d26; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 25 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d27; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 26 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d28; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 27 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d29; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 28 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d30; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 29 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d31; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 30 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,'{$data->C_MONEDA}',{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VALOR_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

      }


      $resultado = $db->query("SELECT @VALOR_ERROR");

      $fila2 = $resultado->fetch_assoc();
    if($fila2['@VALOR_ERROR']=='NO' || $fila2['@VALOR_ERROR']==NULL){

      //$result = array("status"=>true,"message"=>"Orden creada correctamente con el nro:".$fila['@SCODIGO'],"data"=>$data,"error"=>$error);
      $result = array("status"=>true,"codigo"=>$fila['@SCODIGO'],"message"=>"Orden creada correctamente con el nro: ".$fila['@SCODIGO']);

    }
    else{
        $result = array("status"=>false,"message"=>$fila['@VALOR_ERROR']);
    }
    }else{
        //$result = array("status"=>false,"message"=>$fila['@PV_MENSAJE_ERROR'],"data"=>$data);
        $result = array("status"=>false);
}

}
catch(PDOException $e) {

    $result = array("STATUS"=>false,"message"=>$e->getMessage(),"mensaje"=>@PV_MENSAJE_ERROR);

}


  echo  json_encode($result);


});

$app->post("/contrato_cliente",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, TRUE);


   $sql="SELECT * FROM aprendea_auroco.ORD_CONTRATOS  WHERE  C_CLIENTE='{$data['C_CLIENTE']}' order by C_CONTRATO ASC";


   $resultado = $db->query($sql);
   $contratos=array();
   $contratos[]=["ID"=>"0","C_CONTRATO"=>"Seleccionar","C_CLIENTE"=>""];
   while ($fila = $resultado->fetch_object()) {
   $contratos[]=$fila;
   }
   if(count($contratos)>0){
       $data = array("status"=>true,"rows"=>count($contratos),"data"=>$contratos);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contratos,TRUE);

});


$app->post("/contratos_clientes",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, TRUE);


   $sql="SELECT * FROM aprendea_auroco.ORD_CONTRATOS  WHERE  C_CLIENTE='{$data['C_CLIENTE']}' AND INICIO_VIGENCIA<= CURDATE() AND FIN_VIGENCIA>=	CURDATE() order by C_CONTRATO ASC";



   $resultado = $db->query($sql);
   $contratos=array();
   $contratos[]=["ID"=>"0","C_CONTRATO"=>"Seleccionar","C_CLIENTE"=>""];
   while ($fila = $resultado->fetch_object()) {
   $contratos[]=$fila;
   }
   if(count($contratos)>0){
       $data = array("status"=>true,"rows"=>count($contratos),"data"=>$contratos);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contratos,TRUE);

});

$app->get("/tabla/:tabla/:orden",function($tabla,$orden) use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);
   $resultado = $db->query("SELECT * FROM {$tabla} order by {$orden} ASC");
   $datos=array();
   if($tabla='ORD_MEDIOS'){
    $campo='C_MEDIO';
   }

   if($tabla='ORD_EJECUTIVOS'){
    $campo='C_EJECUTIVO';
   }

   $datos[]=["ID"=>"0",$campo=>"0",$orden=>"Seleccionar"];
   while ($fila = $resultado->fetch_object()) {
   $datos[]=$fila;
   }
   if(count($datos)>0){
       $data = array("status"=>true,"rows"=>count($datos),"data"=>$datos);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($datos);

});


$app->get("/contrato_detalle/:id",function($id) use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, TRUE);

   $sql="SELECT ID,C_CONTRATO,C_CLIENTE,date_format(INICIO_VIGENCIA,'%d/%m/%Y') INICIO_VIGENCIA,date_format(FIN_VIGENCIA,'%d/%m/%Y') FIN_VIGENCIA,    NRO_FISICO,   C_MONEDA, INVERSION,INVER_IGV,MONTO_ORDENAR,MONTO_ORD_IGV,TIPO_CAMBIO,TASA_IGV,OBSERVACIONES,C_USUARIO,F_CREACION  ,(SELECT SALDO_ACTUAL FROM ORD_MOVIMIENTO_SALDOS WHERE C_CONTRATO='{$id}' ORDER BY N_MOVIMIENTO DESC LIMIT 1) SALDO_ACTUAL FROM aprendea_auroco.ORD_CONTRATOS WHERE C_CONTRATO='{$id}'";

   $resultado = $db->query($sql);
   $contratos=array();
   while ($fila = $resultado->fetch_object()) {
   $contratos[]=$fila;
   }
   if(count($contratos)>0){
       $data = array("status"=>true,"rows"=>count($contratos),"data"=>$contratos);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contratos,TRUE);

});


$app->get("/medio_programas/:medio",function($medio) use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, TRUE);

    $sql="SELECT p.ID,PROGRAMA,p.TEMA FROM  aprendea_auroco.ORD_PROGRAMAS_AUT p inner join aprendea_auroco.ORD_MEDIOS m where  m.C_MEDIO='{$medio}' AND p.ESTADO='SI' AND m.NOMBRE=p.CANAL ORDER BY PROGRAMA;";
   $resultado = $db->query($sql);
   $contratos=array();
   while ($fila = $resultado->fetch_object()) {
   $contratos[]=$fila;
   }
   /*if(count($contratos)>0){
       $data = array("status"=>true,"rows"=>count($contratos),"data"=>$contratos);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }*/
   echo  json_encode($contratos,TRUE);

});

$app->get("/programa/:id",function($id) use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, TRUE);


   $sql="SELECT * FROM  aprendea_auroco.ORD_PROGRAMAS_AUT where  ID='{$id}' ORDER BY PROGRAMA";
   $resultado = $db->query($sql);
   $contratos=array();
   while ($fila = $resultado->fetch_object()) {
   $contratos[]=$fila;
   }
   if(count($contratos)>0){
       $data = array("status"=>true,"rows"=>count($contratos),"data"=>$contratos);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contratos,TRUE);

});
//REPORTES AUROCO


$app->post("/reporte-contrato-cliente",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);
   $fecha1 = explode("/", $data->FECHA_INICIO);
   $fecha2= explode("/", $data->FECHA_FIN);
   $ano1=explode(" ",$fecha1[2]);
   $ano2=explode(" ",$fecha2[2]);
   $inicio=$ano1[0]."-".$fecha1[1]."-".$fecha1[0];
   $fin=$ano2[0]."-".$fecha2[1]."-".$fecha2[0];

$sql="SELECT CO.C_CONTRATO,C.C_CLIENTE, C.RAZON_SOCIAL,CO.C_MONEDA,CO.INICIO_VIGENCIA,CO.FIN_VIGENCIA, CO.INVERSION, S.SALDO_ACTUAL SALDO
FROM ORD_CONTRATOS CO, ORD_MOVIMIENTO_SALDOS S, ORD_CLIENTES C
WHERE(S.C_CONTRATO = CO.C_CONTRATO)  AND CO.C_CLIENTE = C.C_CLIENTE  AND S.N_MOVIMIENTO = (select max(M.N_MOVIMIENTO) FROM
ORD_MOVIMIENTO_SALDOS M  where M.C_CONTRATO = CO.C_CONTRATO)
and CO.INICIO_VIGENCIA BETWEEN '{$inicio}' AND '{$fin}' and C.C_CLIENTE='{$data->C_CLIENTE}' and CO.C_MONEDA='{$data->MONEDA}' order by INICIO_VIGENCIA;";



   $resultado = $db->query($sql);

   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});

$app->post("/reporte-medios-cliente",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);
   $fecha1 = explode("/", $data->FECHA_INICIO);
   $fecha2= explode("/", $data->FECHA_FIN);
   $ano1=explode(" ",$fecha1[2]);
   $ano2=explode(" ",$fecha2[2]);
   $inicio=$ano1[0]."-".$fecha1[1]."-".$fecha1[0];
   $fin=$ano2[0]."-".$fecha2[1]."-".$fecha2[0];


$sql="SELECT var.c_cliente,var.razon_social,var.nombre,var.c_moneda,sum(inversion) inversion from
(SELECT O.C_CLIENTE,C.RAZON_SOCIAL ,M.C_MEDIO,ME.NOMBRE,O.C_MONEDA,SUM(INVERSION) INVERSION
FROM ORD_ORDENES O,ORD_MEDIOS M, ORD_CLIENTES C,ORD_MEDIOS ME
WHERE O.C_MEDIO=ME.C_MEDIO AND O.C_CLIENTE=C.C_CLIENTE AND O.ACTIVA='SI' AND O.C_MEDIO=M.C_MEDIO AND O.C_MONEDA='{$data->MONEDA}' AND O.C_CLIENTE='{$data->C_CLIENTE}'
AND O.INICIO_VIGENCIA between '{$inicio}' AND '{$fin}' group by O.C_CLIENTE,C.RAZON_SOCIAL,O.C_MEDIO,ME.NOMBRE,O.INICIO_VIGENCIA) var group by 1,2,3 ORDER
BY INVERSION ASC";

   $resultado = $db->query($sql);

   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});

$app->post("/reporte-utilidades",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, false);
   $fecha1 = explode("/", $data->INICIO_VIGENCIA);
   $fecha2= explode("/", $data->FIN_VIGENCIA);
   $ano1=explode(" ",$fecha1[2]);
   $ano2=explode(" ",$fecha2[2]);
   $inicio=$ano1[0]."-".$fecha1[1]."-".$fecha1[0];
   $fin=$ano2[0]."-".$fecha2[1]."-".$fecha2[0];


$sql="SELECT CO.C_CONTRATO,C.C_CLIENTE,C.RAZON_SOCIAL,C.RUC,CO.INICIO_VIGENCIA,CO.FIN_VIGENCIA,
CO.C_MONEDA,CO.INVERSION, (CO.INVERSION - (SELECT SALDO_ACTUAL FROM ORD_MOVIMIENTO_SALDOS WHERE C_CONTRATO=CO.C_CONTRATO AND N_MOVIMIENTO=
(SELECT MAX(N_MOVIMIENTO) FROM ORD_MOVIMIENTO_SALDOS SAL WHERE CO.C_CONTRATO = SAL.C_CONTRATO))) MONTO_ORDENADO,
(SELECT SALDO_ACTUAL FROM ORD_MOVIMIENTO_SALDOS WHERE C_CONTRATO=CO.C_CONTRATO AND N_MOVIMIENTO=
(SELECT MAX(N_MOVIMIENTO) FROM ORD_MOVIMIENTO_SALDOS SAL WHERE CO.C_CONTRATO = SAL.C_CONTRATO)) UTILIDAD FROM ORD_CONTRATOS   CO,
ORD_MOVIMIENTO_SALDOS S, ORD_CLIENTES C
 WHERE(S.C_CONTRATO = CO.C_CONTRATO) AND CO.C_CLIENTE = C.C_CLIENTE  AND S.N_MOVIMIENTO=
(select max(M.N_MOVIMIENTO) from  ORD_MOVIMIENTO_SALDOS M
  where M.C_CONTRATO = CO.C_CONTRATO) and CO.INICIO_VIGENCIA BETWEEN '{$inicio}' AND '{$fin}' AND CO.C_CLIENTE='{$data->C_CLIENTE}' AND CO.C_MONEDA='{$data->C_MONEDA}'
  GROUP BY CO.C_CONTRATO, C.C_CLIENTE,C.RAZON_SOCIAL,C.RUC,CO.MONTO_ORDENAR, CO.C_MONEDA,CO.INICIO_VIGENCIA,CO.FIN_VIGENCIA,CO.INVERSION,S.SALDO_ACTUAL ORDER BY INICIO_VIGENCIA DESC";



   $resultado = $db->query($sql);

   $contrato=array();
   while ($fila = $resultado->fetch_object()) {
   $contrato[]=$fila;
   }
   if(count($contrato)>0){
       $data = array("status"=>true,"rows"=>1,"data"=>$contrato);
   }else{
       $data = array("status"=>false,"rows"=>0,"data"=>null);
   }
   echo  json_encode($contrato);

});



$app->run();