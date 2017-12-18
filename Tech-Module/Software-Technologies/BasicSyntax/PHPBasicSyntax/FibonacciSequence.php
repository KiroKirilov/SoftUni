<form>
    N:<input type="text" name="num">
    <input type="submit"/>
</form>

<?php
if (isset($_GET['num'])) {
    $num=intval($_GET['num']);
    $n1=0;
    $n2=0;
    $n3=1;

    for ($i=0;$i<$num;$i++) {
        echo $n3." ";
        $n1=$n2;
        $n2=$n3;
        $n3=$n1+$n2;
    }
}
