local Card = require("Card")

---@class JokerCard : Card
local JokerCard = setmetatable({}, { __index = Card })
JokerCard.__index = JokerCard

---@param isBigJoker boolean
---@return JokerCard
function JokerCard:new(isBigJoker)
    local instance = Card:new("None", isBigJoker and "BJ" or "LJ")
    instance.isBigJokerFlag = isBigJoker
    setmetatable(instance, JokerCard)
    return instance
end

function JokerCard:display()
    return self.isBigJokerFlag and "BJ" or "LJ"
end

function JokerCard:isJoker()
    return true
end

function JokerCard:isBigJoker()
    return self.isBigJokerFlag
end

return JokerCard
