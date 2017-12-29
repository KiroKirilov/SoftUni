<form>
    N1: <input type="text" name="num1">
    N2: <input type="text" name="num2">
    N3: <input type="text" name="num3">
    <input type="submit"/>
</form>

<?php
if (isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])) {
    $num1=intval($_GET['num1']);
    $num2=intval($_GET['num2']);
    $num3=intval($_GET['num3']);
    $negNums=0;
    if ($num1<0)
        $negNums++;
    if ($num2<0)
        $negNums++;
    if ($num3<0)
        $negNums++;

    if ($negNums%2==0 || $num1==0 || $num2==0|| $num3==0)
        echo "Positive";
    else
        echo "Negative";
}