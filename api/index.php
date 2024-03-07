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

$app->get("/contratos",function() use ($app,$db){
    $json = $app->request->getBody();
   $data = json_decode($json, true);

   $resultado = $db->query("SELECT co.id,co.C_CONTRATO,cl.C_CLIENTE,cl.RAZON_SOCIAL,INICIO_VIGENCIA,FIN_VIGENCIA,NRO_FISICO,C_MONEDA,FORMAT(INVERSION,2) INVERSION,FORMAT(MONTO_ORDENAR,2) MONTO_ORDENAR,TIPO_CAMBIO,OBSERVACIONES,C_USUARIO,co.F_CREACION FROM ORD_CONTRATOS co, ORD_CLIENTES cl where co.C_CLIENTE=cl.C_CLIENTE order by C_CONTRATO DESC");
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


$app->post("/contrato",function() use($db,$app){
    $json = $app->request->getBody();
   $data = json_decode($json,false);


   try {

    $datos=$db->query("SELECT CONCAT('TO',LPAD(substring(max(C_CONTRATO),3,11)+1,3,0)) as ultimo_id FROM ORD_CONTRATOS");

                $identificador=array();

                while ($d = $datos->fetch_object()) {

                 $identificador=$d;
                }

    $sql="call p_contrato('{$identificador->ultimo_id}','{$data->C_CLIENTE}','{$data->INICIO_VIGENCIA}','{$data->FIN_VIGENCIA}','{$data->NRO_FISICO}','{$data->C_MONEDA}',{$data->INVERSION},{$data->MONTO_ORDENAR},{$data->TIPO_CAMBIO},'{$data->OBSERVACIONES}','{$data->C_USUARIO}')";



   $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);

   $result = array("status"=>true,"message"=>"Contrato registrado correctamente con el código: ".$identificador->ultimo_id);

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

   $resultado = $db->query("SELECT CL.C_CLIENTE,RAZON_SOCIAL FROM ORD_CLIENTES CL ORDER  by CL.RAZON_SOCIAL ASC");
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

    $sql="call SP_GRABA_ORDENES('{$data->C_CONTRATO}','{$data->C_CLIENTE}','{$data->C_MEDIO}','{$data->C_EJECUTIVO}','{$data->PRODUCTO}','{$data->MOTIVO}','{$data->DURACION}','{$inicio}','{$fin}','{$data->IGV}','{$data->OBSERVACIONES}','{$data->C_USUARIO}',@SCODIGO,@PV_MENSAJE_ERROR,@VAL_ERROR)";


    $stmt = mysqli_prepare($db,$sql);
    mysqli_stmt_execute($stmt);

    $resultado = $db->query("SELECT @SCODIGO,@PV_MENSAJE_ERROR,@VAL_ERROR");
    $fila = $resultado->fetch_assoc();

    if($fila['@VAL_ERROR']=='NO'){

    foreach ($data->orden as $i => $item) {

        for ($v=0; $v < (int)$item->d1;$v++) {
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$inicio}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d2; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 1 days'));

            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d3; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 2 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d4; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 3 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d5; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 4 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d6; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 5 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d7; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 6 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d8; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 7 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d9; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 8 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";

            $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d10; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 9 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d11; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 10 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d12; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 11 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }
        for ($v=0; $v < (int)$item->d13; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 12 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d14; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 13 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d15; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 14 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d16; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 15 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d17; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 16 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d18; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 17 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d19; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 18 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d20; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 19 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d21; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 20 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d22; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 21 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d23; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 22 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d24; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 23 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d25; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 24 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d26; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 25 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d27; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 26 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d28; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 27 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d29; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 28 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d30; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 29 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

        for ($v=0; $v < (int)$item->d31; $v++) {
            $fec=date('Y-m-d', strtotime($inicio. ' + 30 days'));
            $sql2="call SP_GRABA_LINEA_ORDENES('{$fila['@SCODIGO']}','{$data->C_CONTRATO}','{$fec}','{$item->programa}','{$item->costo}',1,{$v},'{$item->horario}',{$item->costo},'{$data->C_USUARIO}',@VAL_ERROR)";
           $stmt = mysqli_prepare($db,$sql2);
            mysqli_stmt_execute($stmt);
        }

      }


        $result = array("status"=>true,"message"=>"Orden creada correctamente con el nro:".$fila['@SCODIGO'],"data"=>$data);
        }else{
        $result = array("status"=>false,"message"=>$fila['@PV_MENSAJE_ERROR'],"data"=>$data);
        }

}
catch(PDOException $e) {

    $result = array("STATUS"=>false,"message"=>$e->getMessage(),"mensaje"=>@PV_MENSAJE_ERROR);

}


  echo  json_encode($result);


});



$app->post("/contratos_cliente",function() use ($app,$db){
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

    $sql="SELECT p.* FROM  aprendea_auroco.ORD_PROGRAMAS_AUT p, aprendea_auroco.ORD_MEDIOS m where m.NOMBRE=p.CANAL and m.C_MEDIO='{$medio}' ORDER BY PROGRAMA";
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