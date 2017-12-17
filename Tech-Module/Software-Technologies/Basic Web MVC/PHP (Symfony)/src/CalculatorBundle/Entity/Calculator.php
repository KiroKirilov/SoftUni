<?php

namespace CalculatorBundle\Entity;

class Calculator {
    /**
    * @var float
    */
    private $leftOperand;
    /**
     * @var float
     */
    private $rightOperand;
    /**
     * @var string
     */
    private $operator;

    /**
     * @return float
     */
    public function getLeftOperand()
    {
        return $this->leftOperand;
    }

    /**
     * @param float $operand
     * @return Calculator
     */
    public function setLeftOperand(float $operand)
    {
        $this->leftOperand = $operand;
        return $this;
    }

    public function getRightOperand()
    {
        return $this->rightOperand;
    }

    /**
     * @param float $operand
     * @return Calculator
     */
    public function setRightOperand(float $operand)
    {
        $this->rightOperand = $operand;
        return $this;
    }

    /**
     * @return string
     */
    public function getOperator()
    {
        return $this->operator;
    }

    /**
     * @param string $operator
     */
    public function setOperator(string $operator)
    {
        $this->operator = $operator;
    }
}