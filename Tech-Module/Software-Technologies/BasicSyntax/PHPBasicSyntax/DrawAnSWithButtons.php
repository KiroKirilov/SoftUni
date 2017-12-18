<?php
$num=0;
$color="";
for ($row=1;$row<=9;$row++):
    if ($row==1 || $row==5 || $row==9){
        $color="blue";
        $num=1;
    }
    else {
        $num=0;
        $color="";
    }

    for ($col=1;$col<=5;$col++):
        if ($row==1 || $row==5 || $row==9):
            if ($color!=""){
                ?>
                <button style="background-color:<?=$color?>"><?=$num?></button>
            <?php }
            else { ?>
                <button><?=$num?></button>
            <?php }
            if ($col==5)
                echo "<br>";
            ?>
        <?php endif;
        if ($row==2||$row==3||$row==4) {
            if ($col==1){
                $color="blue";
                $num=1;
            }
            else {
                $num=0;
                $color="";
            }
            if ($color!=""){
                ?>
                <button style="background-color:<?=$color?>"><?=$num?></button>
            <?php }
            else { ?>
                <button><?=$num?></button>
            <?php }
            if ($col==5)
                echo "<br>";
            ?>
        <?php }
        if ($row==6||$row==7||$row==8) {
            if ($col==5){
                $color="blue";
                $num=1;
            }
            else {
                $num=0;
                $color="";
            }
            if ($color!="") {
                ?>
                <button style="background-color:<?=$color?>"><?=$num?></button>
            <?php }
            else { ?>
                <button><?=$num?></button>
            <?php }
            if ($col==5)
                echo "<br>";
            ?>
        <?php }
    endfor;
endfor;
?>