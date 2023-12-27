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

   $resultado = $db->query("SELECT * FROM CONTRATOS order by id DESC");
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

$app->post("/contrato",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, true);
   echo  json_encode($data);
});



$app->post("/login",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT * FROM usuarios where usuario='".$data['usuario']."' and password='".$data['password']."'");
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

   $resultado = $db->query("SELECT * FROM CLIENTES order by RAZON_SOCIAL ASC");
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