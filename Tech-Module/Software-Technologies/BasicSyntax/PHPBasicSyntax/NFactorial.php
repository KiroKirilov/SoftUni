<form>
    N:<input type="text" name="num">
    <input type="submit"/>
</form>

<?php
if (isset($_GET['num'])) {
    $num=intval($_GET['num']);
    $fact=1;
    for ($i=1;$i<=$num;$i++) {
        $fact*=$i;
    }
    echo $fact;
}