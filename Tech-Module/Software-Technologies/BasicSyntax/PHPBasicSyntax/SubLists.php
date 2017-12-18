<form>
    N1:<input type="text" name="num1">
    N2:<input type="text" name="num2">
    <input type="submit"/>
</form>

<?php
if (isset($_GET['num1'])&& isset($_GET['num1'])) {
    $num1 = $_GET['num1'];
    $num2 = $_GET['num2']; ?>


    <ul>
        <?php for ($list=1;$list<=$num1;$list++):?>
            <li>List <?=$list?>
                <ul>
                    <?php for ($item=1;$item<=$num2;$item++):?>
                        <li>
                            Element <?=$list?>.<?=$item?>
                        </li>
                    <?php endfor;?>
                </ul>
            </li>
        <?php endfor;?>
    </ul>
    <?php
}
?>