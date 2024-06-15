def invert_last_two_bits(byte):
    # Inverter os dois últimos bits de um byte
    return byte ^ 0b11

def swap_nibbles(byte):
    # Trocar os nibbles (os 4 bits mais significativos com os 4 bits menos significativos)
    return ((byte & 0x0F) << 4) | ((byte & 0xF0) >> 4)

def decrypt_message(ciphertext):
    # Divide a mensagem criptografada em bytes
    encrypted_bytes = ciphertext.split()

    decrypted_bytes = []
    for byte_str in encrypted_bytes:
        byte = int(byte_str, 2)
        # Aplicar a inversão dos últimos 2 bits
        byte = invert_last_two_bits(byte)
        # Aplicar a troca dos nibbles
        byte = swap_nibbles(byte)
        decrypted_bytes.append(byte)

    # Converte os bytes para caracteres ASCII
    decrypted_message = ''.join(chr(byte) for byte in decrypted_bytes)
    return decrypted_message

# Mensagem criptografada fornecida
ciphertext = """
10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 
00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011
"""

# Remove espaços em branco e quebras de linha extras
ciphertext = ciphertext.replace('\n', '').strip()

# Descriptografa a mensagem
plaintext = decrypt_message(ciphertext)

print("Mensagem descriptografada:")
print(plaintext)
