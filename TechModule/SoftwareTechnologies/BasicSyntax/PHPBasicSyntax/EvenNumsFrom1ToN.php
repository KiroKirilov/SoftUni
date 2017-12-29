<form>
    N: <input type="text" name="num">
    <input type="submit"/>
</form>

<?php
if (isset($_GET['num'])) {
    $num=intval($_GET['num']);
    for ($i=2;$i<=$num;$i+=2)
        echo $i." ";
}