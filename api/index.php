<?php

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

$app->get("/contratos",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT co.id,co.C_CONTRATO,cl.C_CLIENTE,cl.RAZON_SOCIAL,INICIO_VIGENCIA,FIN_VIGENCIA,NRO_FISICO,C_MONEDA,INVERSION,MONTO_ORDENAR,TIPO_CAMBIO,OBSERVACIONES FROM ORD_CONTRATOS co, ORD_CLIENTES cl where co.C_CLIENTE=cl.C_CLIENTE order by C_CONTRATO DESC");
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
    $resultado = $db->query("SELECT * FROM MONEDAS order by idMONEDAS");
   $monedas=array();
   while ($fila = $resultado->fetch_object()) {
   $monedas[]=$fila;
   }

   echo  json_encode($monedas);

    });



$app->post("/contrato",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json,false);


   try {

    $datos=$db->query("SELECT CONCAT('T0',max(id)+1) ultimo_id FROM ORD_CONTRATOS;");

                $identificador=array();

                while ($d = $datos->fetch_object()) {

                 $identificador=$d;
                 }



   $sql="call p_contrato('{$identificador->ultimo_id}','{$data->C_CLIENTE}','{$data->INICIO_VIGENCIA}','{$data->FIN_VIGENCIA}','{$data->NRO_FISICO}','{$data->C_MONEDA}',{$data->C_MONTO_PAGAR},{$data->C_MONTO_ORDENAR},{$data->TIPO_CAMBIO},'{$data->OBSERVACIONES}','{$data->C_USUARIO}')";

   $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);

   $result = array("status"=>true,"numero"=>"112","message"=>"Contrato registrado correctamente");
   }
   catch(PDOException $e) {
    $result = array("STATUS"=>false,"message"=>$e->getMessage());
   }

    echo  json_encode($result);

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

   $resultado = $db->query("SELECT * FROM ORD_CLIENTES order by c_cliente ASC");
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

    $sql="call SP_GRABA_ORDENES('{$data->C_CONTRATO}','{$data->C_CLIENTE}','{$data->C_MEDIO}','{$data->C_EJECUTIVO}','{$data->PRODUCTO}','{$data->MOTIVO}','{$data->DURACION}','{$inicio}','{$fin}','{$data->IGV}','{$data->OBSERVACIONES}',@SCODIGO,@PV_MENSAJE_ERROR)";
    $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);
    $result = array("status"=>true,"message"=>"Orden creada correctamente","data"=>$data);

}
catch(PDOException $e) {

    $result = array("STATUS"=>false,"message"=>$e->getMessage());
   }

//echo  ($sql);

  echo  json_encode($result);


});



$app->post("/contratos_cliente",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, TRUE);


   $sql="SELECT * FROM aprendea_auroco.ORD_CONTRATOS  WHERE  C_CLIENTE='{$data['C_CLIENTE']}' order by C_CONTRATO ASC";


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

$app->get("/tabla/:tabla/:orden",function($tabla,$orden) use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM {$tabla} order by {$orden} ASC");
   $datos=array();
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


   $sql="SELECT * FROM aprendea_auroco.ORD_CONTRATOS WHERE C_CONTRATO='{$id}'";
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


   $sql="SELECT p.* FROM  aprendea_auroco.ORD_PROGRAMAS_AUT p, aprendea_auroco.ORD_MEDIOS m where m.NOMBRE=p.CANAL and CANAL='{$medio}' ORDER BY PROGRAMA;";
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

$app->run();